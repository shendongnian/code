        static void Main()
        {
            DateTime currentDate = DateTime.Now.Date;            
            //Mock dataTable is used instead of stored procedure resultset
            DataTable dt = new DataTable();
            dt.Columns.Add("Date", typeof(DateTime));
            dt.Rows.Add("2015-08-11");
            dt.Rows.Add("2015-08-13");
            string xmlFile = "hours.xml";            
            var isDateFound = from row in dt.AsEnumerable()
                              where row.Field<DateTime>("Date") == currentDate
                              select row;
            if (isDateFound.Count() > 0)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlFile);
                var node = doc.DocumentElement.SelectSingleNode("TotalHours");
                node.InnerText = (Convert.ToInt32(node.InnerText) + 8).ToString();
                doc.Save(xmlFile);
            }         
        }
         
