     try {
                    List<string[]> words1 = new List<string[]>();
                    string[] stopWords = File.ReadAllLines(@"C:\Users\~\Desktop\stopWords_E_Unique_Spaces.txt");
    
                    using (SqlConnection con = new SqlConnection("Data Source=Source_Name;Initial Catalog=subset_aminer;Integrated Security=True"))
                    {
                        con.Open();
                        using (SqlCommand query = con.CreateCommand())
                        {
                            query.CommandText = "select p_abstract from sub_aminer_paper where aid = 52883";
                            SqlDataReader reader = query.ExecuteReader();
                            while (reader.Read())
                            {
                                string[] ListElements = new string[2];
                                ListElements[0] = reader["p_abstract"].ToString();
                                ListElements[1] = reader["p_abstract"].ToString();
                                words1.Add(ListElements);
                            }
                            reader.Close();
                        }
                    }
                    for (int index = 0; index < words1.Count; index++)
                    {
                        foreach (string word in stopWords)
                        {
                            var item = words1.ElementAt(index);
                            item[1] = item[1].ToString().ToLower().Replace(word, " ").Trim();
                            item[1] = Regex.Replace(item[1].ToString(), @"\s+", " ");
                        }
                    }
                    using (SqlConnection con = new SqlConnection("Data Source=Source_Name;Initial Catalog=subset_aminer;Integrated Security=True"))
                    {
                        con.Open();
                       
                            for (int i = 0; i < words1.Count; i++)
                            {
                                var item      = words1.ElementAt(i);
                                var itemKey   = item[0].ToString();
                                var itemValue = item[1].ToString();
                                    
                                string query = "select id from sub_aminer_paper where p_abstract LIKE @p_abstract and aid = 52883";
    
                                using (SqlCommand cmd = new SqlCommand(query, con))
                                {
                                    //string inp = input;
                                    cmd.Parameters.AddWithValue("@p_abstract", itemKey);
                   
                                    int id = 0;
                                    using (SqlDataReader reader = cmd.ExecuteReader())
                                    {
                                        while (reader.Read())
                                        {
                                            id = reader.GetInt32(0);
                                        }
                                        reader.Close();
                                    }
                                   
                                
                                string update_query = "update sub_aminer_paper set p_abstract_SWR = @p_abstract_SWR where id = @id";
                                int res = 0;
                                using (SqlCommand cmd_update = new SqlCommand(update_query, con))
                                {
                                    int identity = id;
                                    string p_abstractSWR = itemValue;
    
                                    cmd_update.Parameters.AddWithValue("@id", identity);
                                    cmd_update.Parameters.AddWithValue("@p_abstract_SWR", p_abstractSWR);
                                
                                    res = cmd_update.ExecuteNonQuery();
                                } 
                            }
                        }
                        con.Close();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
