    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Data;
    using System.Data.SqlClient;
    namespace ConsoleApplication21
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                StreamReader reader = new StreamReader(FILENAME);
                string inputLine = "";
                List<TakenBMI> takenBMIs = new List<TakenBMI>();
                TakenBMI newTakenBMI = null;
                while ((inputLine = reader.ReadLine()) != null)
                {
                    inputLine = inputLine.Trim();
                    if (inputLine.Length > 0)
                    {
                        string[] inputArray = inputLine.Split(new char[] { ':' });
                        switch (inputArray[0].Trim())
                        {
                            case "Name of House":
                                newTakenBMI = new TakenBMI();
                                takenBMIs.Add(newTakenBMI);
                                newTakenBMI.Name_of_House = inputArray[1].Trim();
                                break;
                            case "Townland":
                                newTakenBMI.Townland = inputArray[1].Trim();
                                break;
                            case "Near":
                                newTakenBMI.Near = inputArray[1].Trim();
                                break;
                            case "Status/Public Access":
                                newTakenBMI.Status_Public_Access = inputArray[1].Trim();
                                break;
                            case "Date Built":
                                newTakenBMI.Date_Built = inputArray[1].Trim();
                                break;
                        }
                    }
                }
                reader.Close();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                con.Open();
                string SQL = "INSERT INTO Houses (Name, Townland, Near, Status, Built)" +
                    "VALUES ('@name', '@town', '@near', '@status', '@built')";
                SqlCommand com = new SqlCommand(SQL,con);
               
                com.Parameters.Add("@name", SqlDbType.NVarChar);
                com.Parameters.Add("@town", SqlDbType.NVarChar);
                com.Parameters.Add("@near", SqlDbType.NVarChar);
                com.Parameters.Add("@status", SqlDbType.NVarChar);
                com.Parameters.Add("@built", SqlDbType.NVarChar);
     
                foreach (TakenBMI takenBMI in takenBMIs)
                {
                    com.Parameters["@name"].Value = takenBMI.Name_of_House ;
                    com.Parameters["@town"].Value = takenBMI.Townland;
                    com.Parameters["@near"].Value = takenBMI.Near;
                    com.Parameters["@status"].Value = takenBMI.Status_Public_Access;
                    com.Parameters["@built"].Value = takenBMI.Date_Built;
                   
                    com.ExecuteNonQuery();
                }
            }
        }
        public class TakenBMI
        {
            public string Name_of_House { get; set; }
            public string Townland { get; set; }
            public string Near { get; set; }
            public string Status_Public_Access { get; set; }
            public string Date_Built { get; set; }
        }
    }
