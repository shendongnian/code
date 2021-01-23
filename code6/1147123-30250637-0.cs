        static void Main(string[] args)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;
            XmlReader Reader = XmlReader.Create("items.xml", settings);
            int value = 500;
            int credit = 0;
            var DiscountPercent = 0.1f;
            while (Reader.Read())
            {
                if (Reader.NodeType == XmlNodeType.Element)
                {
                    #region MyRegion
                    if (Reader.Name == "Amount")
                    {
                        if ("Amount" == "Gold" || value > 4999)
                        {
                            credit = 300;
                            DiscountPercent = .20f;
                        }
                        else if ("Amount" == "Silver" || value > 4999)
                        {
                            DiscountPercent = .15f;
                        }
                        else if ("Amount" == "Regular")
                        {
                            credit = 200;  //unreachable code detected
                        }
                        Reader.Read();
                    }
                    else if (Reader.Name == "Member")
                    {
                        if ("Member" == "Gold" || value > 4999)
                        {
                            credit = 300;
                            DiscountPercent = .20f;
                        }
                        else if ("Member" == "Silver" || value > 4999)
                        {
                            DiscountPercent = .15f;
                        }
                        else if ("Member" == "Regular")
                        {
                            credit = 200;  //unreachable code detected
                        }
                        Reader.Read();
                    }
                    
                    #endregion                
                }
            }
        }
