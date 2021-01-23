    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Caching;
    using System.Web.Hosting;
    namespace Admin.UI.Utility
    {
    public class VirtualCompiler
    {
        protected static Dictionary<String, String> _code = new Dictionary<String, String>();
        public static void Add(String Name, String Code)
        {
            Name = Name.ToUpper();
            if (_code.ContainsKey(Name))
                _code.Remove(Name);
            _code.Add(Name, Code);
        }
        public static String Get(String Name)
        {
            Name = Name.ToUpper();
            if (_code.ContainsKey(Name))
                return _code[Name];
            return String.Empty;
        }
        public static Boolean Exists(String Name)
        {
            Name = Name.ToUpper();
            return _code.ContainsKey(Name);
        }
    }
    public class VirtualControl : VirtualFile
    {
        public String WebControlContent = String.Empty;
        public VirtualControl(String VirtualPath)
            : base(VirtualPath)
        {
            int ndx = VirtualPath.LastIndexOf("/");
            String filename = ndx >= 0 ? VirtualPath.Substring(ndx + 1) : VirtualPath;
            WebControlContent = VirtualCompiler.Get(filename);
        }
        public override System.IO.Stream Open()
        {
            MemoryStream ms = new MemoryStream();
            if (!String.IsNullOrWhiteSpace(WebControlContent))
            {
                byte[] data = System.Text.ASCIIEncoding.ASCII.
                GetBytes(WebControlContent);
                ms.Write(data, 0, data.Length);
            }
            ms.Flush();
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }
    }
    public class VirtualControlProvider : VirtualPathProvider
    {
        public static void AppInitialize()
        {
            VirtualControlProvider db = new VirtualControlProvider();
            System.Web.Hosting.HostingEnvironment.RegisterVirtualPathProvider(db);
        }
        public override CacheDependency GetCacheDependency(string VirtualPath, IEnumerable VirtualPathDependencies, DateTime UTCStart)
        {
            return IsPathVirtual(VirtualPath) ? null : base.GetCacheDependency(VirtualPath, VirtualPathDependencies, UTCStart);
        }
        private bool IsPathVirtual(string VirtualPath)
        {
            String checkPath = VirtualPathUtility.ToAppRelative(VirtualPath);
            return checkPath.StartsWith("~/DynamicCode/".ToLower().ToString(), StringComparison.InvariantCultureIgnoreCase);
        }
        public override bool FileExists(String VirtualPath)
        {
            if (IsPathVirtual(VirtualPath))
            {
                VirtualControl file = (VirtualControl)GetFile(VirtualPath);
                // Determine whether the file exists on the virtual file 
                // system.
                if (file != null && !String.IsNullOrWhiteSpace(file.WebControlContent))
                    return true;
                else
                    return Previous.FileExists(VirtualPath);
            }
            else
                return Previous.FileExists(VirtualPath);
        }
        public override VirtualFile GetFile(String VirtualPath)
        {
            if (IsPathVirtual(VirtualPath))
            {
                return new VirtualControl(VirtualPath);
            }
            else
                return Previous.GetFile(VirtualPath);
        }
    }
}
