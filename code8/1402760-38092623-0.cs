    var values = final.Split(new string[] { "16XY" }, StringSplitOptions.RemoveEmptyEntries).ToList();
    
                List <YourModel> models = new List<YourModel>();
    
                foreach (var item in values)
                {
                    if (item.IndexOf('+') > 0) {
                        var itemSplit = item.Split('+');
                        if (itemSplit[0].Length > 15 && itemSplit[1].Length > 10)
                            models.Add(new YourModel(itemSplit[0].Substring(0, 16), itemSplit[1].Substring(0, 11)));
                    }
                }
