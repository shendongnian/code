    results.GroupBy(item => item.UploadDate, 
                   (key, grouping) => new SearchData 
                   { 
                        UploadDate = key, 
                        Images = grouping.Select(item => new UserImage
                        {
                            FileName = item.FileName,
                            FileId = item.FileId 
                        }).ToList() 
                   } 
