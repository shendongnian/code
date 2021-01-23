    /* VIRTUAL PATH HELPER */
    public class ViewPathProvider : VirtualPathProvider
    {
        //private static FormDBContext dbForm = new FormDBContext();
        public override bool FileExists(string virtualPath)
        {
            return IsExistByVirtualPath(virtualPath) || base.FileExists(virtualPath);
        }
        public override VirtualFile GetFile(string virtualPath)
        {
            if (IsExistByVirtualPath(virtualPath))
            {
                return new ViewFile(virtualPath);
            }
            return base.GetFile(virtualPath);
        }
        public override CacheDependency GetCacheDependency(string virtualPath, System.Collections.IEnumerable virtualPathDependencies, DateTime utcStart)
        {
            if (IsExistByVirtualPath(virtualPath)) {
                //return null; //return null to force no cache
                return ViewCacheDependencyManager.Instance.Get(virtualPath); //uncomment this to enable caching
            }
            return Previous.GetCacheDependency(virtualPath, virtualPathDependencies, utcStart);
        }
        public override String GetFileHash(String virtualPath, IEnumerable virtualPathDependencies) //uncomment this getfilehash to turn on cache
        {
            if (IsExistByVirtualPath(virtualPath))
            {
                return Guid.NewGuid().ToString();
            }
            return Previous.GetFileHash(virtualPath, virtualPathDependencies);
        }
        public bool IsExistByVirtualPath(string virtualPath)
        {
            bool isExist = false;
            try
            {
                string checker = virtualPath.First().Equals('~') ? virtualPath : "~" + virtualPath;
                if (checker.IndexOf("/Views/", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    checker = "~" + Helper.RemoveSubfolderName(checker);
                }
                using (FormDBContext formsDB = new FormDBContext())
                {
                    List<Form> f = formsDB.Forms.Where(m => m.VirtualPath.Equals(checker, StringComparison.CurrentCultureIgnoreCase)).ToList();
                    if ((f != null) && (f.Count > 0))
                    {
                        isExist = true;
                        base.GetFile(virtualPath);
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.Log("Is Exist By Virtual Path: " + ex);
            }
            return isExist;
        }
    }
    public class VirtualForm
    {
        //private FormDBContext dbForm = new FormDBContext();
        public string GetByVirtualPath(string virtualPath)
        {
            using (FormDBContext dbForm = new FormDBContext())
            {
                string content = string.Empty;
                string checker = virtualPath.First().Equals("~") ? virtualPath : "~" + virtualPath;
                if (checker.IndexOf("/Views/", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    checker = "~" + Helper.RemoveSubfolderName(checker);
                }
                Form f = dbForm.Forms.Where(m => m.VirtualPath.Equals(checker, StringComparison.CurrentCultureIgnoreCase)).First();
                content = f.Html;
                return content;
            }
        }
    }
    public class ViewFile : VirtualFile
    {
        private string path;
        public ViewFile(string virtualPath)
            : base(virtualPath)
        {
            path = virtualPath;
        }
        public override Stream Open()
        {
            if (string.IsNullOrEmpty(path))
                return new MemoryStream();
            VirtualForm vf = new VirtualForm();
            string content = vf.GetByVirtualPath(path);
            if (string.IsNullOrEmpty(content))
                return new MemoryStream();
            return new MemoryStream(ASCIIEncoding.UTF8.GetBytes(content));
        }
    }
    public class ViewCacheDependencyManager
    {
        private static Dictionary<string, ViewCacheDependency> dependencies = new Dictionary<string, ViewCacheDependency>();
        private static volatile ViewCacheDependencyManager instance;
        private static object syncRoot = new Object();
        private ViewCacheDependencyManager()
        {
        }
        public static ViewCacheDependencyManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new ViewCacheDependencyManager();
                        }
                    }
                }
                return instance;
            }
        }
        public CacheDependency Get(string virtualPath)
        {
            if (!dependencies.ContainsKey(virtualPath))
                dependencies.Add(virtualPath, new ViewCacheDependency(virtualPath));
            /*else //This else will always reset cache when it is virtual path
            {
                dependencies.Remove(virtualPath);
                dependencies.Add(virtualPath, new ViewCacheDependency(virtualPath));
            }*/
            return dependencies[virtualPath];
            
        }
        public void Invalidate(string virtualPath)
        {
            string vp = virtualPath.First().Equals('~') ? virtualPath.Remove(0, 1) : virtualPath;
            if (dependencies.ContainsKey(vp))
            {
                var dependency = dependencies[vp];
                dependency.Invalidate();
                dependency.Dispose();
                dependencies.Remove(vp);
            }
        }
        public void InvalidateAll()
        {
            dependencies.Clear();
        }
    }
    public class ViewCacheDependency : CacheDependency
    {
        public ViewCacheDependency(string virtualPath)
        {
            base.SetUtcLastModified(DateTime.UtcNow);
        }
        public void Invalidate()
        {
            base.NotifyDependencyChanged(this, EventArgs.Empty);
        }
    }
