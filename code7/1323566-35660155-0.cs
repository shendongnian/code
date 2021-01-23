    [Serializable]
    [XmlRoot("DbConnections")]
    public class DbConnections
    {
       List<DbConnectionInfo> DbConnectionInfos;
       Boolean UseWindowsAuthentication;
    }
