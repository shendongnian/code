        public void xmlToCSVfiltered(string p, int e, string nodeName, char delimiter)
        {
            //get the xml node
            XDocument xml = XDocument.Load(p);
            //get the required node. I am assuming you would know. For eg. Event Node
            var requiredNode = xml.Descendants(nodeName);
            foreach (var node in requiredNode)
            {
                if (node == null)
                    continue;
                //Also here, I am assuming you have the delimiter knowledge.
                var valueSplit = node.Value.Split(delimiter);
                foreach (var value in valueSplit)
                {
                    if (value == e.ToString())
                    {
                        AddToCSV();
                    }
                }
            }
        }
