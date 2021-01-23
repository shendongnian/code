     using (XmlWriter writer = nav.AppendChild())
     {
         writer.Settings.Indent = true;
         XmlSerializer ser = new XmlSerializer(typeof(List<T>), overrides);
         ser.Serialize(writer, _depositorsOperationsList);
     }
