        XmlNodeList xnList2 = xml.SelectNodes("/roor/body/queries");
                                foreach (XmlNode xn2 in xnList2)
                                {
                                    foreach (XmlNode childNode in xn2.ChildNodes)
                                    {
                    
                                        queries = childNode.InnerText;
                                        // text should return only first query text, but I need all the query text
                                        query_string = "INSERT INTO Customer_Queries values (@query)";
                                        using(SqlConnection myConnection = new SqlConnection(constr))
                                        {
                                            myConnection.Open();
                                            using(SqlCommand myCommand = new SqlCommand(query_string, myConnection))
                                            {
                                               myCommand.parameters.AddWithValue("@query", queries);
                                               myCommand.ExecuteNonQuery();
                                            }
                                        }        
                                    }
                                }
