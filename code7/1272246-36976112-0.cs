      public List<List<string>> GetDataAsList(string query)
        {
            try
            {
                intializeConnection();
               
                        DataTable dataTable;
                        DataSet dataset = new DataSet();
                        List<List<string>> data;
                        query = query.Trim().ToUpper();
                        DataRow row = null;
                        string[] commasCount;
                        string[] commasCountWithoutFrom;
                        if (query.Contains('*'))
                        {
                            return null;
                        }
                        commasCount = query.Trim().Split(new string[] { "FROM" }, StringSplitOptions.None);
                        string commasString = commasCount[0].Trim();
                        commasCountWithoutFrom = commasString.Trim().Split(',');
                        ArrayList columnsName2 = new ArrayList();
                        for (int c = 0; c < commasCountWithoutFrom.Length; c++)
                        {
                            string raw = commasCountWithoutFrom[c].Trim();
                            string[] parts = raw.Trim().Split(' ');
                            string sub_parts = parts[parts.Length - 1];
                            columnsName2.Add(sub_parts.ToString());
                        }
                List<List<string>> resultArr=null;
            
                string cmdStr = String.Format(query);
                command = new SqlCommand(cmdStr, connection);
                set = new DataSet();
                adapter = new SqlDataAdapter(command);
                adapter.Fill(set);
                if (set.Tables[0].Rows.Count > 0)
                {
                    resultArr = new List<List<string>>();
                  
                    
                    for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                    {
                        resultArr.Add(new List<string>());
                        for (int col = 0; col < columnsName2.Count; col++)
                        {
                           
                            resultArr[i].Add(set.Tables[0].Rows[i][columnsName2[col].ToString()].ToString().Trim());
                        }
                    }
                }
                else
                {
                   
                        resultArr = new List<List<string>>();
                        resultArr.Add(new List<string>());
                        for (int col = 0; col < columnsName2.Count; col++)
                        {
                            resultArr[0].Add("No Data");
                        }
                 
                }
               
                connection.Close();
                return resultArr;
            }
            catch (SystemException ex)
            {
                connection.Close();
                return null;
            }
        }
