      private MemoryStream _XmlAndXslToHtml(string sXml, string sXslt)
        {
            var myXslTrans = new XslCompiledTransform();
            var style = XmlReader.Create(new StringReader(sXslt));
            var data = XmlReader.Create(new StringReader(sXml));
            var retval = new MemoryStream();
            var settings = new XmlWriterSettings();
            settings.Encoding = Encoding.GetEncoding(850);
            settings.OmitXmlDeclaration = true;
            var output = XmlWriter.Create(retval, settings);
            //output.Settings.OmitXmlDeclaration = true;
            myXslTrans.Load(style);
            myXslTrans.Transform(data, output);
            return retval;
        }
