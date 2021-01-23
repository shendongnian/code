                        using (WebClient client = new WebClient())
                        {
                            response = Newtonsoft.Json.Linq.JObject.Parse(client.DownloadString(fullUrl));
                        }
        
                        Newtonsoft.Json.Linq.JArray items = response.items;
        
                        Newtonsoft.Json.Linq.JArray selectedItems = new JArray();
        
                        foreach (dynamic rev in reviews)
                        {
                            if (rev.propertyWanted == "condition")
                            {
                                selectedReviews.Add(rev);
                            }
                            else
                            {
                                continue;
                            }
                        }
                        
                        return selectedReviews;
