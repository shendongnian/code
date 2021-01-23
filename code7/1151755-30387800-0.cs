    //String Declaration
    string Sqlstr = "select CountryCode,Description,Nationality from  ca_countryMaster where isDeleted=0 and CountryCode = 'CAN' ";
    
    string DBCon = "Data Source=RAJA;Initial Catalog=CareHMS;Integrated Security=True;";
                
                SqlConnection SqlCon = new SqlConnection(DBCon);
                SqlDataAdapter Sqlda;
                DataSet ds = new DataSet();
    
                try
                {
                    SqlCon.Open();
                    Sqlda = new SqlDataAdapter(Sqlstr, SqlCon);
                    Sqlda.Fill(ds);
    
                    gdView.DataSource = ds.Tables[0];
                    gdView.DataBind();
                }
                catch (Exception ex)
                {
                    lbl.text = ex.Message;
                }
                finally
                {
                    ds.Dispose();                
                    SqlCon.Close();
                }
