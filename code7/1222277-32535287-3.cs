        var result = list.GroupBy(x => x.Column1).Select(y => new
        {
            C1 = y.Key,
            C1Children = y.GroupBy(z => z.Column2).Select(m => new
            {
                C2 = m.Key,
                C2Children = m.Select(n => n.Column3)
            })
        });
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        var jsonResult = serializer.Serialize(test);
