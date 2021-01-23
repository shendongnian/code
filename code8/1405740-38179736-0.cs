    class MyClass
    {    
        static _lockObject = new Object();
        void MyMethod()
        {
            var root = new XmlDocument();
            lock (_lockObject )
            {
                root.Load(reader);
                if (root.DocumentElement.Name == "FC_FeatureCatalogue")
                    TransformCatalogue(ref reader);
            }
            afc = (AC_FeatureCatalogueType)ser.Deserialize(reader);           
        }
    }
