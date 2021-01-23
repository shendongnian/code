    public class Class1
    {
       static void Main()
       {
           SqlConnection conn = new SqlConnection(connection);
           conn.Open();
           SqlCommand cmd = new SqlCommand("calculatesaturday", conn);
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.Add("@firstsaturday", SqlDbType.Date).Value = "2015-08-08";
           SqlDataReader reader = cmd.ExecuteReader();
           DataTable dt1 = new DataTable();
           dt1.Load(reader);
           conn.close();
           string xmlFile1 = "xmlfile.xml"; 
           DateTime currentDate1 = DateTime.Now.Date;
           var isDateFound = from row in dt1.AsEnumerable()
                             where row.Field<DateTime>("StartDate") == currentDate1
                             select row;
           if (isDateFound.Count() > 0)
           {
               XmlDocument doc = new XmlDocument();
               doc.Load(xmlFile1);
               var node = doc.DocumentElement.SelectSingleNode("TotalHours");
               node.InnerText = (Convert.ToInt32(node.InnerText) + 8).ToString();
               doc.Save(xmlFile1);
           }       
       }      
