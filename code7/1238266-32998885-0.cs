    // C# classes for the XML structure
    using System.Xml.Serialization;
    
    namespace PlaneterXml
    {
        [XmlRoot(Namespace = "", IsNullable = false)]
        public partial class Planeter
        {
            private Planet[] itemsField;
    
            [XmlElement("Planet", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public Planet[] Items
            {
                get { return this.itemsField; }
                set { this.itemsField = value; }
            }
        }
    
        [XmlType(AnonymousType = true)]
        public partial class Planet
        {
            public string Namn { get; set; }
            public int Dygnslangd { get; set; }
            public int Arslangd { get; set; }
        }
    }
    // C# code to read the XML (deserialize it) and then insert
    // the planets read from the file into the database table
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    
    namespace PlaneterXml
    {
        class Program
        {
            static void Main(string[] args)
            {
                // adapt to *your* file name - possibly put this in a 
                // configuration file, or pick the file interactively 
                string fileName = @"C:\tmp\planeter.xml";
    
                Planeter allPlanets = null;
    
                using (FileStream fstm = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    // create XML serializer for the "Planeter" type
                    XmlSerializer planetSerializer = new XmlSerializer(typeof(Planeter));
                    // deserialize the XML into a "Planeter" object    
                    allPlanets = planetSerializer.Deserialize(fstm) as Planeter;
                }
    
                // Define connection string and insert query
                // connection string would typically come from a config file
                string connectionString = @"server=.;database=test;integrated security=SSPI;";
                string insertQuery = @"INSERT INTO dbo.Planets(Namn, Dygnslangd, Arslangd) VALUES(@Namn, @Dygnslangd, @Arslangd);";
    
                // create SqlConnection and SqlCommand to insert
                using (SqlConnection conn  =new SqlConnection(connectionString))
                using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                {
                    // define parameters
                    insertCmd.Parameters.Add("@Namn", SqlDbType.VarChar, 100);
                    insertCmd.Parameters.Add("@Dygnslangd", SqlDbType.Int);
                    insertCmd.Parameters.Add("@Arslangd", SqlDbType.Int);
    
                    // open connection, loop over planets, execute query
                    conn.Open();
    
                    foreach (Planet p in allPlanets.Items)
                    {
                        // set parameter values
                        insertCmd.Parameters["@Namn"].Value = p.Namn;
                        insertCmd.Parameters["@Dygnslangd"].Value = p.Dygnslangd;
                        insertCmd.Parameters["@Arslangd"].Value = p.Arslangd;
    
                        insertCmd.ExecuteNonQuery();
                    }
    
                    // close connection
                    conn.Close();
                }
            }
        }
    }
