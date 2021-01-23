           Class1 c1 = new Class1();//Your Model class
           var content = new ObjectContent<Class1>(c1,
           GlobalConfiguration.Configuration.Formatters.XmlFormatter);
            return new HttpResponseMessage()
            {
                Content = content
            };
