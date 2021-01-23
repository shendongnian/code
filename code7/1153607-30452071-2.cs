    class Program
    {
        static void Main(string[] args)
        {
            string mainPath = "C:\\xmlTest"; //folder with my xml files goes here, it's optional, you can change it to whatever you want
            Data data = new Data();
            foreach (string file in Directory.EnumerateFiles(mainPath, "*.xml"))
            {
                XmlSerializer mySerializer = new XmlSerializer(typeof(Data));
                StreamReader streamReader = new StreamReader(file);
                data = (Data)mySerializer.Deserialize(streamReader);
                streamReader.Close();
                List<Row> rows = data.Msgs.RowsObj.RowsList;
				
				foreach (var row in rows)
                        {
							//do stuff here
							//example: string paymentType = row.InvoiceCode.Substring(row.InvoiceCode.Length - 2);
						}
              
            }
        }
    }
