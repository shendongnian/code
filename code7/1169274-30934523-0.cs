    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using System.Data;
    using System.Data.SqlClient;
    
    namespace StopWords_Removal
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                  
                    string[] stopWords = File.ReadAllLines(@"C:\stopWords.txt");
    
                    SqlConnection con = new SqlConnection("Data Source=ABC;Initial Catalog=xyz;Integrated Security=True");
    
                    con.Open();
                    SqlCommand query = con.CreateCommand();
                    query.CommandText = "select text from table where id between 1 and 500 and DATALENGTH(text) != 0";
    
                    SqlDataReader reader = query.ExecuteReader();
    
                    var summary = new List<string>();
                    while(reader.Read())
                    {
                        summary.Add(reader["p_abstract"].ToString());
                    }
                    
                    reader.Close();
                    string[] input_Texts = summary.ToArray();
                   
                    for (int i = 0; i < input_Texts.Length; i++)
                    {
                        for (int j = 0; j < input_Texts.Length; j++)
                        {
                            input_Texts[j] = string.Join(" ", input_Texts[j].Split(' ').Except(input_Texts[j].Split(' ').Intersect(stopWords)));
                        }
                    }
    
                    for (int d = 0; d < input_Texts.Length; d++)
                    {
                        Console.WriteLine(input_Texts[d]); 
                        Console.ReadLine();
                    }
                  
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                    Console.WriteLine("Executing finally block.");
                } 
            }
        }
    }
