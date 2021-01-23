     public List<dcTransaction>  SelectMasterTransaction(DateTime date1, DateTime date2)
            {
                List<dcTransaction> result = new List<dcTransaction>();
                string conString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (con = new SqlConnection(conString))
                {
                    SqlCommand cmd = new SqlCommand("spViewMasterTransaction", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter parameterDate1 = new SqlParameter();
                    parameterDate1.ParameterName = "@date1";
                    parameterDate1.Value = date1;
                    cmd.Parameters.Add(parameterDate1);
                    SqlParameter parameterDate2 = new SqlParameter();
                    parameterDate2.ParameterName = "@date2";
                    parameterDate2.Value = date2;
                    cmd.Parameters.Add(parameterDate2);
                    con.Open();
                    SqlDataReader dtReader = cmd.ExecuteReader();
                    while (dtReader.Read())
                    {
                        dcTransaction dcTrans = new dcTransaction();
                        dcTrans.no_trans = int.Parse(dtReader["no_trans"].ToString());
                        dcTrans.name = dtReader["name"].ToString();
                        dcTrans.sum = int.Parse(dtReader["sum"].ToString());
                        dcTrans.dates = DateTime.Parse(dtReader["dates"].ToString());
                        result.Add(dcTrans); 
                    }
                }
                return result;
            }
