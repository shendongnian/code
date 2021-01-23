    public static string OpenMathToMathML(string source) {
        var trans = new XslCompiledTransform();
        using (var fs = File.OpenRead("omtocmml.xsl")) {
            var settings = new XmlReaderSettings
            {
                DtdProcessing = DtdProcessing.Parse
            };
            
            using (var schemaReader = XmlReader.Create(fs, settings)) {
                trans.Load(schemaReader);
                using (var ms = new MemoryStream()) {
                    using (var sreader = new StringReader(source)) {
                        using (var reader = XmlReader.Create(sreader)) {
                            trans.Transform(reader, null, ms);
                            return Encoding.UTF8.GetString(ms.ToArray());
                        }
                    }
                }
            }
        }
    }
