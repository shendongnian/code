        private static void AddMissingNodes(XmlDocument doc)
        {
            var query = from nodeDef in doc.GetElementsByTagName("DEFINITION-REF").Cast<XmlNode>()
                        where nodeDef.InnerText == "/AUTOSAR/Com/ComConfig/ComSignal"
                        from nodeDefSibling in nodeDef.ParentNode.ChildNodes.Cast<XmlNode>()
                        where nodeDefSibling.Name == "PARAMETER-VALUES"
                        from paramNode in nodeDefSibling.ChildNodes.Cast<XmlNode>()
                        where paramNode.Name == "FUNCTION-NAME-VALUE"
                        select new
                        {
                            paramNode = paramNode,
                            func_child_list = (from funChild in paramNode.ChildNodes.Cast<XmlNode>()
                                              where funChild.Name == "DEFINITION-REF"
                                               select funChild).ToList() // Snapshot func_child_list by calling ToList()
                        };
            foreach (var paramNodeAndFuncChildren in query.ToList()) // Snapshot everything by calling ToList()
                foreach (var funChild in paramNodeAndFuncChildren.func_child_list)
                    AddMissingNodes(doc, paramNodeAndFuncChildren.paramNode, funChild);
        }
        private static void AddMissingNodes(XmlDocument doc, XmlNode paramNode, XmlNode funChild)
        {
            string tout = "/AUTOSAR/Com/ComConfig/ComSignal/ComTimeoutNotification";
            string comnotify = "/AUTOSAR/Com/ComConfig/ComSignal/ComNotification";
            string invalid = "/AUTOSAR/Com/ComConfig/ComSignal/ComInvalidNotification";
            if (funChild.InnerText != tout)
            {
                if (funChild.InnerText != comnotify)
                {
                    //ADD ComInvalidNotification tags
                    XmlNode newNode = doc.CreateElement("FUNCTION-NAME-VALUE");
                    paramNode.AppendChild(newNode);
                    XmlNode defRefNode = doc.CreateElement("DEFINITION-REF");
                    XmlAttribute attr = doc.CreateAttribute("DEST");
                    attr.Value = "FUNCTION-NAME-DEF";
                    defRefNode.Attributes.SetNamedItem(attr);
                    newNode.AppendChild(defRefNode);
                    XmlNode val = doc.CreateElement("VALUE");
                    val.InnerText = "ComInvalidNotification";//ComInvalidNotification + shortName ;
                    newNode.AppendChild(val);
                }
                else
                {
                    //ADD ComNotification tags
                    XmlNode newNode = doc.CreateElement("FUNCTION-NAME-VALUE");
                    paramNode.AppendChild(newNode);
                    XmlNode defRefNode = doc.CreateElement("DEFINITION-REF");
                    XmlAttribute attr = doc.CreateAttribute("DEST");
                    attr.Value = "FUNCTION-NAME-DEF";
                    defRefNode.Attributes.SetNamedItem(attr);
                    newNode.AppendChild(defRefNode);
                    XmlNode val = doc.CreateElement("VALUE");
                    val.InnerText = "ComNotification Node";//ComNotification + shortName;
                    newNode.AppendChild(val);
                }
            }
            else
            {
                //ADD ComTimeOutNotification tags
                XmlNode newNode = doc.CreateElement("FUNCTION-NAME-VALUE");
                paramNode.AppendChild(newNode);
                XmlNode defRefNode = doc.CreateElement("DEFINITION-REF");
                XmlAttribute attr = doc.CreateAttribute("DEST");
                attr.Value = "FUNCTION-NAME-DEF";
                defRefNode.Attributes.SetNamedItem(attr);
                newNode.AppendChild(defRefNode);
                XmlNode val = doc.CreateElement("VALUE");
                val.InnerText = "ComTimeoutNotification node";//ComInvalidNotification + shortName;
                newNode.AppendChild(val);
            }
        }
 
