        var result = list.Select(x => x.Column1).Distinct().Select(y => new
        {
            Level1 = y,
            Level2List = list.Where(z => z.Column1 == y).Select(y1 => y1.Column2).Distinct().Select(z1 => new
            {
                Level2 = z1,
                Level3List = list.Where(m => m.Column2 == z1).Select(n => n.Column3)
            })
        }).ToList();
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        var jsonResult = serializer.Serialize(result);
