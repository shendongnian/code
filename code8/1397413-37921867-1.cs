    public void GetDier(string naam)
            {
                var con = ConfigurationManager.ConnectionStrings["Yourconnection"].ToString();
    Dieren naamValue= new Dieren();
                using (SqlConnection myConnection = new SqlConnection(con))
                {
                    string oString ="SELECT * FROM [Dieren] WHERE Diersoort = @Diersoort";
                    SqlCommand oCmd = new SqlCommand(oString, myConnection);
                    oCmd.Parameters.AddWithValue("@Diersoort", naam);           
                    myConnection.Open();
                    using (SqlDataReader oReader = oCmd.ExecuteReader())
                    {
                        while (oReader.Read())
                        {    
                            naamValue.naam= oReader["naam"].ToString();                       
                        }
    
                        myConnection.Close();
                    }               
                }
                return naamValue;
            }
