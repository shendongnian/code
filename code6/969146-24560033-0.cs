    var list = new List<string>();
                list.Add("100lbs");
                list.Add("10lbs");
                list.Add("10pts");
    
                var groupings = list.GroupBy((s)=>{
                    if (s.EndsWith("lbs"))//you can use regex here 
                    {
                        return "lbs";
                    }
                    else if (s.EndsWith("lbs"))
                    {
                        return "pts";
                    }
                    return "none";
                },s=>s);
                foreach (var item in groupings)
                {
                    item.key will have category "lbs"/"pts" 
                }
