        static void Main(string[] args)
        {
            string strXML = File.ReadAllText("xml.xml");
            XDocument xmlsrcdoc = XDocument.Parse(strXML);
            using (SqlConnection connection = new SqlConnection("<Your Connection String>"))
            {
                SqlCommand command = connection.CreateCommand();
                connection.Open();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_InsertXMLData";
                XElement XMLData = new XElement("Root",
                    from xml in xmlsrcdoc.Descendants("cliente").Descendants("cliente")
                    select new XElement("CSVDataRecord",
                        new XAttribute("no_cliente", xml.Element("no_cliente").Value),
                        new XAttribute("nombre", xml.Element("nombre").Value),
                        new XAttribute("ap_paterno", xml.Element("ap_paterno").Value),
                        new XAttribute("ap_materno", xml.Element("ap_materno").Value),
                        new XAttribute("calle", xml.Element("calle").Value),
                        new XAttribute("ciudad_cliente", xml.Element("ciudad_cliente").Value),
                        new XAttribute("password", xml.Element("password").Value)
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
