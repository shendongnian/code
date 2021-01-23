            foreach (String s in sourceLocations)
            {
                Dictionary<string, string> sourceTemp = new Dictionary<string, string>();
                Dictionary<string, object> Temp = new Dictionary<string, object>();
                using (ResXResourceReader rsxr = new ResXResourceReader(s))
                {
                    rsxr.UseResXDataNodes = true;
                    foreach (DictionaryEntry entry in rsxr)
                    {
                        string[] parts = s.Split('\\');
                        if ((!entry.Key.ToString().Contains(">>")))
                        {
                            if (isNodeString((ResXDataNode)entry.Value))
                            sourceTemp.Add(parts[parts.Count() - 1] + "_" + entry.Key.ToString(), getNodeValue((ResXDataNode)entry.Value));
                        }
                    }
                    sources.Add(sourceTemp);
                }
            }
        private string getNodeValue(ResXDataNode node)
        {
            if (node.FileRef == null)
            {
                return node.GetValue((ITypeResolutionService)null).ToString();
            }
            else return String.Empty;
        }
        private bool isNodeString(ResXDataNode node)
        {
            string result =  node.GetValueTypeName((ITypeResolutionService)null);
            if (result.Contains("System.String")) return true;
            else return false;
        }
