    var result = new SearchResult
    {
        Success = true,
        SearchData = results.GroupBy(item => item.UploadDate, 
                   (key, grouping) => new SearchData 
                   { 
                        UploadDate = key, 
                        Images = grouping.Select(item => new UserImage
                        {
                            FileName = item.FileName,
                            FileId = item.FileId 
                        }).ToList() 
                   } ).ToList()
    };
    var json = new JavaScriptSerializer().Serialize(result);
    var json_otherWay = Newtonsoft.Json.JsonConvert.SerializeObject(result);
