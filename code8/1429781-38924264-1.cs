        private void DoIt()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"M:\StackOverflowQuestionsAndAnswers\38924171\38924171\data.xml");
            XmlNode node;
            node = xmlDoc.DocumentElement;
            //string name = node.Attributes[0].Value;
            string name = node["Account"].InnerText;
        }
