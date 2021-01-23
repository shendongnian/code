            foreach(var item in list)
            {
                XmlElement elem = doc.CreateElement(string.Format("Attachment{0}", list.IndexOf(item)));
                node.AppendChild(elem);
                XmlNode subNode = root.SelectSingleNode(string.Format("//Attachment{0}", list.IndexOf(item)));
                XmlAttribute xKey = doc.CreateAttribute(string.Format("INDEX{0}", list.IndexOf(item).ToString()));
                xKey.Value = item;
                subNode.Attributes.Append(xKey);
            }
