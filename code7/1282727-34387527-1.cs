    string adsdetSqlSelect = @"select AD.[AdsID],
                                      AD.[UID],
                                      AD.[Section],
                                      AD.[Category],
                                      AD.[Country],
                                      AD.[State],
                                      AD.[City],
                                      AD.[AdsTit],
                                      UI.[Logo],
                                      UI.[Img],
                                      UI.[TeleNum],
                                      UI.[Email]
                                 from [ads] as AD 
                                 join UserInfo as UI 
                                   ON AD.[UID] = UI.[UID] 
                                where AD.AdsID = @AID";
    SqlConnection con = new SqlConnection(cs);
    SqlCommand adsdeCM = new SqlCommand(adsdetSqlSelect, con);
    try{
        con.Open();
        SqlDataReader sdr = cmd.ExecuteReader();
        sdr.Read();
        showernumlbl.Text = sdr["Shower"].ToString();
        carmakerlbl.Text = sdr["Maker"].ToString();
        Label2.Text = sdr["Garage"].ToString();
        CountCurrencLbl.Text = sdr["Currency"].ToString();
        ExtLinkHPLINK.NavigateUrl = sdr["extlink"].ToString();
    }
    catch(Exception ex){
        //Catch exceptions and work with them
    }
    finally{
        con.Close();
    }
