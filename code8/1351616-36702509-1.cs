    static void RunThroughSession()
            {
                string objectName = "MyObject";
    
                var template = Activator.CreateInstance<BusinessObjectTemplate>();
                TextTemplatingSession session = new TextTemplatingSession();
                session["XmlFileName"] =
                    @"C:\Users\XXXXX\Documents\Visual Studio 2012\Projects\XXXXXX.Templates\XXXXXX.Templates.CodeGenerator\" + objectName + ".xml";
    
                template.Session = session;
                template.Initialize();
                string outputText = template.TransformText();
                using (StreamWriter sr = new StreamWriter(
                    @"C:\Users\XXXXX\Documents\Visual Studio 2012\Projects\XXXXX.Templates\XXXXXX.Templates.CodeGenerator\GeneratedCode\BusinessObject" + objectName + ".cs"))
                {
                    sr.Write(outputText);
                }
