    XmlElement root = doc.CreateElement("node");
    doc.AppendChild(root);
    using (DbDataReader dr = command.ExecuteReader())
    {
        while (dr.Read())
        {
            #region Field Matrices
            // Field Matrix
            r01  = dr.GetValue(0).ToString();
            r11  = dr.GetValue(1).ToString();
            r21  = dr.GetValue(2).ToString();
            XmlElement subnode = doc.CreateElement("subnode");
            root.AppendChild(subnode);
            XmlAttribute newAttribute = subnode.CreateAttribute("name");
            newAttribute.Value = r01;        
            child.Attributes.Append(newAttribute);
            XmlAttribute newAttribute = subnode.CreateAttribute("sum");
            newAttribute.Value = r11  + r21;        
            subnode.Attributes.Append(newAttribute);
        }
    }
 
    doc.Save(Console.Out);
