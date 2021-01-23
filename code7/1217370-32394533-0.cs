        public bool FunEnable(string funName, string isEnable)
        {
            bool result = true;
            XDocument xDL = XDocument.Load("C://XMLFile2.xml");
            var xSingleNode = from node in xDL.Descendants("itemb")
                              where node.Attribute("FunName").Value == funName
                              select node;
            if(xSingleNode.Count() > 0)
            {
                result = xSingleNode.ElementAt(0).Attribute("isEnable").Value == "true";
                //If there is at least one node with the given name, result is set to the first nodes "isEnable"-value
            }
            return result;
        }
