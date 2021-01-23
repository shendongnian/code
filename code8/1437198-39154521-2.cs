    public IEnumerable<Test> ParseXml(string path)
    {
        bool isTitle = false;
        bool isText = false;
        
        using (XmlReader Reader = XmlReader.Create(FilePath))
        {
            Test tt = new Test();
            while (Reader.Read())
            {                    
                switch (Reader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (Reader.Name == "title")
                        {
                            isTitle = true;
                        }
                        if (Reader.Name == "text")
                        {
                            isText = true;
                        }
                        break;
                    
                    case XmlNodeType.Text:
                        if (isTitle)
                        {
                            tt.Title = Reader.Value;
                            isTitle = false;
                        }
    
                        if (isText)
                        {
                            tt.Text = Reader.Value;
                            isText = false;
                        }
                        break;
                }
    
                if (tt.Text != null)
                {
                    yield return tt;
                    tt = new Test();
                }
            }
        }
    }
