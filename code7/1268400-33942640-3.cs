    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                            {
                                //
                                // Create new reques object
                                //
                                RequestObject rObj = new RequestObject();
                                rObj.k = ConfigurationManager.AppSettings["restkey"].ToString();
                                rObj.source = row["SearchText"].ToString();
                                rObj.isUrl = "0";
                                rObj.ISO2Code = "be";
    
                                streamWriter.Write(JsonConvert.SerializeObject(rObj));
                                streamWriter.Flush();
                                streamWriter.Close();
                            }
