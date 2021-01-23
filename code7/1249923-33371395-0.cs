     private static void BuildXML()
     {
         using (SqlConnection con = new SqlConnection("Data Source=TEST;Initial Catalog=BLMERISK;Integrated Security=True"))
         {
             using (SqlCommand buildXML = new SqlCommand("usp_BUILD_RISKCALC_XML", con))
             {
                  buildXML.CommandType = CommandType.StoredProcedure;
                  con.Open();
 
                  XmlReader xmlReader = buildXML.ExecuteXmlReader();
                  XmlDocument xdoc = new XmlDocument();
                  xdoc.Load(xmlReader);
                  xdoc.Save("Test.xml");
             }
         }
    }
