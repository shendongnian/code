    public static  MyReturnType ShutterstockSearchResults(string url)
        { 
           MyReturnType result=new MyReturnType();
           int TotalCont=0;
    
            DataTable dt = new DataTable();
            try
            {
                //intigration using Basic Aouth with authrization headers
    
                var request = (HttpWebRequest)WebRequest.Create(url);
                var username = "SC";
                var password = "SK";
                string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(username + ":" + password));
                request.Headers[HttpRequestHeader.Authorization] = string.Format("Basic {0}", credentials);
                request.UserAgent = "MyApp 1.0";
                var response = (HttpWebResponse)request.GetResponse();
                using (var stream = response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    var objText = reader.ReadToEnd();
                    SearchResult myojb = (SearchResult)js.Deserialize(objText, typeof(SearchResult));
                   TotalCount = myojb.total_count;          
    
                    dt.Columns.Add("Id");
                    dt.Columns.Add("Discription");
                    dt.Columns.Add("Small_Thumb_URl");
                    dt.Columns.Add("Large_Thumb_URL");
                    dt.Columns.Add("Prieview_URL");
                    dt.Columns.Add("ContributorID");
                    dt.Columns.Add("aspect");
                    dt.Columns.Add("image_type");
                    dt.Columns.Add("is_illustration");
                    dt.Columns.Add("media_type");
                    foreach (var item in myojb.data)
                    {
                        var row = dt.NewRow();
                        row["ID"] = item.id;
                        row["Discription"] = item.description;
                        row["Small_Thumb_URl"] = item.assets.small_thumb.url;
                        row["Large_Thumb_URL"] = item.assets.large_thumb.url;
                        row["Prieview_URL"] = item.assets.preview.url;
                        row["ContributorID"] = item.contributor.id;
                        row["aspect"] = item.aspect;
                        row["image_type"] = item.image_type;
                        row["is_illustration"] = item.is_illustration;
                        row["media_type"] = item.media_type;
                        dt.Rows.Add(row);
                    }
                    // List<SearchResult> UserList = JsonConvert.DeserializeObject<List<SearchResult>>(objText);
                    // Response.Write(reader.ReadToEnd());
                }          
    
            }
    
            catch (WebException ea)
            {
    
                Console.WriteLine(ea.Message);
                using (var stream = ea.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    Console.WriteLine(reader.ReadToEnd());
                }
            }
    
            result.TheDataTable=dt;
            result.TotalCount=TotalCount;
            return result:
    
        }
