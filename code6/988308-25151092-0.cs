            string _xml = "<IDs><ID>1</ID><ID>2</ID><ID>3</ID><ID>4</ID></IDs>";
            XmlTextReader _xtr = new XmlTextReader(new StringReader(_xml));
            _xtr.WhitespaceHandling = WhitespaceHandling.Significant;
            XmlDocument _xdoc = new XmlDocument();
            _xdoc.Load(_xtr);
            XmlElement root = _xdoc.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("/IDs/ID");
            int[] _ids = new int[4];
            int i = 0;
            foreach (XmlNode node in nodes)
            {
                _ids[i] = Convert.ToInt32(node.InnerText);
                i++;
            }
