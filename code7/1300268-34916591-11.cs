        namespace XMLWritingFromDB
    {
        public class Program
        {
            public static string connectionstring = "Data Source=RAHIMPC\\SQLEXPRESS;Initial Catalog=Test;Integrated Security=false;uid=******;pwd=********";
            public static SqlConnection conn;
            static void Main(string[] args)
            {
    
                //Get the table Informations 
                DataTable dt = GetDataSchema("table_1"); // PUT YOUR TABLE NAME HERE.
                string xmlDocument = PrepareXml(dt);
                Console.Write(xmlDocument);
                Console.ReadKey();
               
            }
    
            public static DataTable GetDataSchema(string TableName)
            {
                DataTable dt = new DataTable();
                string query = "SELECT Col.Column_Name, Case When( CHARINDEX('PK_' , Col.CONSTRAINT_NAME) >0 ) Then 'PK' ELSE 'FK' END as Type " +
                    " from INFORMATION_SCHEMA.TABLE_CONSTRAINTS Tab, INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE Col " +
                    " WHERE Col.Constraint_Name = Tab.Constraint_Name AND Col.Table_Name = Tab.Table_Name " +
                    "AND (Constraint_Type = 'PRIMARY KEY'  OR Constraint_Type = 'Foreign KEY') AND Col.Table_Name = 'table_1'";
    
                using (conn = new SqlConnection(connectionstring))
                {
                    conn.Open();
                    using (SqlCommand sc = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader dr = sc.ExecuteReader())
                        {
                            dt.Load(dr);
                        }
                    }
                    conn.Close();
                }
                return dt;
            }
    
            public static string PrepareXml(DataTable dt)
            {
                int pkCount = 0, fkCount = 0;
                List<string> lstPK = new List<string>();
                List<string> lstFK = new List<string>();
                //Build data for xml
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr[1].ToString().Contains("PK"))
                    {
                        pkCount++;
                        lstPK.Add(dr[0].ToString());
                    }
                    if (dr[1].ToString().Contains("FK"))
                    {
                        fkCount++;
                        lstFK.Add(dr[0].ToString());
                    }
                }
    
                List<TableName> lstXml = new List<TableName>();
                TableName xml = new TableName();
                xml.key = lstPK[lstPK.Count() - 1].ToString();
    
                xml.ForeignKey = lstFK;
                if (pkCount > 1)
                    xml.Composite = lstPK;
    
                var stringwriter = new System.IO.StringWriter();
                var serializer = new XmlSerializer(xml.GetType());
                serializer.Serialize(stringwriter, xml);
                return stringwriter.ToString();
            }
        }
    
        [XmlRoot("TableName")]
        public class TableName
        {
            public string key { get; set; }
    
            [XmlArray(ElementName = "Composite")]
            [XmlArrayItem("ColumnName", Type = typeof(string))]
            public List<string> Composite { get; set; }
    
            [XmlArray(ElementName = "ForeignKey")]
            [XmlArrayItem("ColumnName", Type = typeof(string))]
            public List<string> ForeignKey { get; set; } 
    
        }
    }
