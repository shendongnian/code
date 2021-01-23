                   WebRequest request = WebRequest.Create(url);
                    // If required by the server, set the credentials.r
                    request.Credentials = CredentialCache.DefaultCredentials;
                    request.ContentType = "application/xml; charset=utf-8";
                    // Get the response.
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    //// Display the status.
                    //Console.WriteLine(response.StatusDescription);
                    //// Get the stream containing content returned by the server.
                    Stream dataStream = response.GetResponseStream();
                    //   Open the stream using a StreamReader for easy access.
                    StreamReader reader = new StreamReader(dataStream);
                    // Read the content. 
                    string responseFromServer = reader.ReadToEnd();
    
                    DataSet ds = new DataSet();
    
                    ds.ReadXml(new StringReader(responseFromServer));
    
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            strArrNames.Add(ds.Tables[0].Rows[i]["Name"].ToString());
                            strArrEmails.Add(ds.Tables[0].Rows[i]["Email"].ToString());
                            strArrTitles.Add(ds.Tables[0].Rows[i]["Title"].ToString());
                            strArrBalanceDays.Add(ds.Tables[0].Rows[i]["BalanceDays"].ToString());
                            strArrLoanDueDates.Add(ds.Tables[0].Rows[i]["loanDueDate"].ToString());
                    
                        }
    
                        overduestatus = true;
    
                    }
