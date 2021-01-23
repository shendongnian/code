                    var jss = new JavaScriptSerializer();
                    var dict = jss.Deserialize<Dictionary<string, dynamic>>(strRet);
                    StringBuilder sbErr = new StringBuilder(string.Format("{0} ({1}): {2}", rep.StatusDescription, dict["code"], Environment.NewLine));
                    if ((dict["errors"] is Dictionary<string, dynamic>)) {
                        foreach (KeyValuePair<string, dynamic> item in dict["errors"]) { 
                            sbErr.AppendFormat("{0}=", item.Key);
                            foreach (string item2 in item.Value)
                                sbErr.AppendFormat("{0}. ", item2);
                        }
                    }
