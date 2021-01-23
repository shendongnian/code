        static void Main(string[] args)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;
            XmlReader Reader = XmlReader.Create("items.xml", settings);
            int value = 500;
            int credit = 0;
            var DiscountPercent = 0.1f;
            var amountType = "Gold";  //variable, not constant
            var memberType = "Gold";  //variable, not constant
            while (Reader.Read())  //generally people use lower case for variables "reader.Read()"
            {
                if (Reader.NodeType == XmlNodeType.Element)
                {
                    #region MyRegion
                    if (Reader.Name == "Amount")
                    {
                        if ("Amount" == amountType || value > 4999)
                        {
                            credit = 300; 
                            DiscountPercent = .20f;
                        }
                        else if ("Amount" == amountType || value > 4999)
                        {
                            DiscountPercent = .15f;
                        }
                        else if ("Amount" == amountType)
                        {
                            credit = 200;  //no error, code is now reachable
                        }
                        Reader.Read();
                    }
                    else if (Reader.Name == "Member")
                    {
                        if ("Member" == memberType || value > 4999)
                        {
                            credit = 300;
                            DiscountPercent = .20f;
                        }
                        else if ("Member" == memberType || value > 4999)
                        {
                            DiscountPercent = .15f;
                        }
                        else if ("Member" == memberType)
                        {
                            credit = 200;  //no error, code is now reachable
                        }
                        Reader.Read();
                    }
                    #endregion                
                }
            }
        }
