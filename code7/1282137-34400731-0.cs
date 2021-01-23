                {
                    //Get the json and convert it to a Dictionary note the new dictionary will contain nested dictionaries
                    string json = "However You get it";
                    var jss = new JavaScriptSerializer();
                    var dict = jss.Deserialize<Dictionary<string, dynamic>>(json);
                    //Loop thru the nested Dictionary to get the values you need
                    for (int i = 0; i < dict.Values.Sum(x =>x.Count); i++)
                    {
                        foreach (var item in dict)
                        {
                       
                            Label2.Text = (dict["data"][i]["attributes"]["firstName"]);
                        }
                    }
                    
                }
