       public static void Main()
        {
            string xml = "<Data><Units><Unit Id=\"1\" IsActive=\"true\" /><Unit Id=\"2\" IsActive=\"true\" /></Units><Product Id=\"16\" Code=\"C3\" ><Names><Name NameVersion=\"1\" Name=\"C3 \" /></Names><Units><Unit Id=\"16\"/></Units></Product></Data>";
            var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(xml));
            XmlTextReader reader = new XmlTextReader(memoryStream);
            while (reader.Read())
            {
                //keep reading until we see a book element 
                if (reader.Name.Equals("Unit") &&
                    (reader.NodeType == XmlNodeType.Element))
                {
                    if (reader.GetAttribute("Id") == "1" || reader.GetAttribute("Id") == "2")
                    {
                        string isActive = reader.GetAttribute("IsActive");
                    }
                    else
                    {
                        reader.Skip();
                    }
                }
            }
        }
