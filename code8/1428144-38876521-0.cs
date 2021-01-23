    using (SqlConnection conn = new SqlConnection(connStr)) {
       conn.Open();
       using (SqlCommand cmnd = new SqlCommand("dbo.spMyStoredProcXML", conn)) {
         cmnd.CommandType = CommandType.StoredProcedure;
         cmnd.Parameters.AddWithValue("@Param1", "Some value";)
          //more parameters...
         XmlReader xrdr = cmnd.ExecuteXmlReader();
          //do stuff...
         }
      }
