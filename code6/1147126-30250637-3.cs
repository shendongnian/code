        static void Main(string[] args)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;
            XmlReader reader = XmlReader.Create("items.xml", settings);
            int value = 500;
            int credit = 0;
            var discountPercent = 0.1f;  //generally people use lower case for variables
            var amountType = "Gold";  //added this variable to replace constant
            var memberType = "Gold";  //added this variable to replace constant
            while (reader.Read())  //generally people use lower case for variables "reader.Read()"
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name == "Amount")
                    {
                        //two constant but different strings will never equal each other...
                        //, just like the integer 1 will never equal 2
                        if ("Amount" == amountType || value > 4999)  
                        {
                            credit = 300; 
                            discountPercent = .20f;
                        }
                        else if ("Amount" == amountType || value > 4999)
                        {
                            discountPercent = .15f;
                        }
                        else if ("Amount" == amountType)
                        {
                            credit = 200;  //no error, code is now reachable
                        }
                        reader.Read();
                    }
                    else if (reader.Name == "Member")
                    {
                        if ("Member" == memberType || value > 4999)
                        {
                            credit = 300;
                            discountPercent = .20f;
                        }
                        else if ("Member" == memberType || value > 4999)
                        {
                            discountPercent = .15f;
                        }
                        else if ("Member" == memberType)
                        {
                            credit = 200;  //no error, code is now reachable
                        }
                        reader.Read();
                    }                
                }
            }
        }
