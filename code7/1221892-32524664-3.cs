    using System.Web.Script.Serialization; //this is needed for some classes
    
    [DataContract] //these attributes hel the serializer to serialize the object
    internal class UserDetails
    {
        [DataMember]
        public string ImageName { get; set; }
        [DataMember]
        public string Descript { get; set; }
        [DataMember]
        public string ImageAssignedName { get; set; }
    }
    protected static IEnumerable<UserDetails> GetFabrics()
    {
        var details = new List<UserDetails>();
        using (var connnection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString.ToString()))
        using (var cmd = new SqlCommand("SELECT Fabrics.ImageName,Fabrics.Descript,ImageAssignedName from Fabrics", connnection))
        {
            var reader = cmd.ExecuteReader();
            
            while(reader.Read())
            {
                yield return new UserDetails
                {
                    ImageName = reader.GetString(0),
                    Descript = reader.GetString(0),
                    ImageAssignedName = reader.GetString(0),
                };
            }
        }
    }
    
    [WebMethod]
    public static string BindDataGrid()
    {
        var result = GetFabrics(); //this is a IEnumerable<UserDetails>, 
        
        var jsonSerialiser = new JavaScriptSerializer();
        var json = jsonSerialiser.Serialize(result); //this does everyting
        
        return json;
    }
    
