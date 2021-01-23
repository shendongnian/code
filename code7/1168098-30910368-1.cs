     public static String XmlToHtml(String inputXml, String transformXsl)
        {
            XslCompiledTransform xslTransform = new XslCompiledTransform(false);
            using (StringReader sr = new StringReader(transformXsl))
            {
                using (XmlReader xr = XmlReader.Create(sr))
                {
                    xslTransform.Load(xr);
                }
            }
            string result = String.Empty;
            using (StringReader sr = new StringReader(inputXml))
            {
                using (XmlReader xr = XmlReader.Create(sr))
                {
                    using (StringWriter sw = new StringWriter())
                    {
                        xslTransform.Transform(xr, null, sw);
                        result = sw.ToString();
                    }
                }
            }
            return result;
        }
