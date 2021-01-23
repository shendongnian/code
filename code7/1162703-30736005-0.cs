    public class PartialsTransform : IBundleTransform
        {
            private readonly string _moduleName;
            public PartialsTransform(string moduleName)
            {
                _moduleName = moduleName;
            }
    
            public void Process(BundleContext context, BundleResponse response)
            {
                var strBundleResponse = new StringBuilder();
                // Javascript module for Angular that uses templateCache 
                strBundleResponse.AppendFormat(
                    @"angular.module('{0}').run(['$templateCache',function(t){{",
                    _moduleName);
    
                foreach (var file in response.Files)
                {
                    // Get the partial page, remove line feeds and escape quotes
                    var content = File.ReadAllText(file.FullName)
                        .Replace("\r\n", "").Replace("'", "\\'");
                    // Create insert statement with template
                    strBundleResponse.AppendFormat(
                        @"t.put('partials/{0}','{1}');", file.Name, content);
                }
                strBundleResponse.Append(@"}]);");
    
                response.Files = new FileInfo[] {};
                response.Content = strBundleResponse.ToString();
                response.ContentType = "text/javascript";
            }
        }
