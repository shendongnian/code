        static void Main(string[] args)
        {
            string strXML = File.ReadAllText("xml.xml");
            XDocument xmlsrcdoc = XDocument.Parse(strXML);
            using (SqlConnection connection = new SqlConnection("<Your connection string>"))
            {
                SqlCommand command = connection.CreateCommand();
                connection.Open();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_InsertXMLData";
                XElement XMLData = new XElement("Root",
                    from xml in xmlsrcdoc.Descendants("cliente").Descendants("cliente")
                    select new XElement("CSVDataRecord",
                        new XAttribute("no_cliente", (string)xml.Element("no_cliente") ?? ""),
                        new XAttribute("nombre", (string)xml.Element("nombre") ?? ""),
                        new XAttribute("ap_paterno", (string)xml.Element("ap_paterno") ?? ""),
                        new XAttribute("ap_materno", (string)xml.Element("ap_materno") ?? ""),
                        new XAttribute("calle", (string)xml.Element("calle") ?? ""),
                        new XAttribute("ciudad_cliente", (string)xml.Element("ciudad_cliente") ?? ""),
                        new XAttribute("password", (string)xml.Element("password") ?? "")
                    )
                );
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@InputXML",
                    SqlDbType = SqlDbType.Xml,
                    Value = new SqlXml(XMLData.CreateReader())
                });
                command.ExecuteNonQuery();
            }
        }
