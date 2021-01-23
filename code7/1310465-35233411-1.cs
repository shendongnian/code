    public string BodyContent
        {
            get
            {
                string content = "";
                
                Type type = this.GetType();
                Assembly assembly = Assembly.GetExecutingAssembly();
                string resource = String.Format("{0}.{1}", type.Namespace, this.Resource);
                Stream stream = assembly.GetManifestResourceStream(resource);
                StreamReader reader = new StreamReader(stream);
                content = reader.ReadToEnd();
                return content;
            }
        }
