    public class MyClass
    {
        public string Name { get; set; }
        public List<string> FavoriteThings { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var myObject = new MyClass();
            myObject.Name = "Gord";
            var myFavs = new List<string>();
            myFavs.Add("bicycles");
            myFavs.Add("ham");
            myObject.FavoriteThings = myFavs;
            var xs = new System.Xml.Serialization.XmlSerializer(myObject.GetType());
            var sw = new System.IO.StringWriter();
            xs.Serialize(sw, myObject);
            using (var con = new OleDbConnection())
            {
                con.ConnectionString =
                        @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                        @"Data Source=C:\Users\Public\Database1.accdb;";
                con.Open();
                using (var cmd = new OleDbCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "INSERT INTO tblObjects (ObjectID, ObjectXML) VALUES (?,?)";
                    cmd.Parameters.AddWithValue("?", 1);
                    cmd.Parameters.AddWithValue("?", sw.ToString());
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }
    }
