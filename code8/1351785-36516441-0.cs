    protected void Application_Start()
            {
                RazorViewEngine engine = (RazorViewEngine)ViewEngines.Engines[1];
                List<string> currentFormats =  engine.ViewLocationFormats.ToList();
                currentFormats.Insert(0,"~/Views/{1}es/{0}.cshtml");
                engine.ViewLocationFormats = currentFormats.ToArray();
                ... Other application start code
            }
