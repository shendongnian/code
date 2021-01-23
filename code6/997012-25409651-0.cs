    public class LicensedStyleBundle : Bundle
    {
        public LicensedStyleBundle(string virtualPath)
            : base(virtualPath)
        {
            this.Builder = new LicencedStyleBuilder();
        }
    
        public LicensedStyleBundle(string virtualPath, string cdnPath)
            : base(virtualPath, cdnPath)
        {
            this.Builder = new LicencedStyleBuilder();
        }
    }
 
    public class LicencedStyleBuilder : IBundleBuilder
    {
        public virtual string BuildBundleContent(Bundle bundle, BundleContext context, IEnumerable<BundleFile> files)
        {
            var content = new StringBuilder();
            foreach (var file in files)
            {
                FileInfo f = new FileInfo(HttpContext.Current.Server.MapPath(file.VirtualFile.VirtualPath));
                CssSettings settings = new CssSettings();
                settings.IgnoreAllErrors = true; //this is what you want
                settings.CommentMode = Microsoft.Ajax.Utilities.CssComment.Important;
                var minifier = new Microsoft.Ajax.Utilities.Minifier();
                string readFile = Read(f);
                string res = minifier.MinifyStyleSheet(readFile, settings);
                content.Append(res);
            }
    
            return content.ToString();
        }
    
        public static string Read(FileInfo file)
        {
            using (var r = file.OpenText())
            {
                return r.ReadToEnd();
            }
        }
    }
