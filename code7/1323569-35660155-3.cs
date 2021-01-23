    XmlSerializer serializer = new XmlSerializer(typeof(DbConnections));
                string xml;
                using (StringWriter textWriter = new StringWriter())
                {
                    serializer.Serialize(textWriter, oDbConnections);
                    xml = textWriter.ToString();
                }
    <?xml version="1.0" encoding="utf-16"?>
    <DbConnections xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
      <DbConnectionInfo>
        <ServerName>test</ServerName>
      </DbConnectionInfo>
      <DbConnectionInfo>
        <ServerName>test 2</ServerName>
      </DbConnectionInfo>
      <UseWindowsAuthentication>true</UseWindowsAuthentication>
    </DbConnections>
