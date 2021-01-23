    var data = (from g in fpslist.GroupBy(x => x.Ration_Card_Type1).Select(x => new
                {
                    CardType_Name = x.Key,
                    CardType_Count = x.Sum(y => y.Ration_Card_Count1)
                }).Union(
                  fpslist.GroupBy(x => x.Ration_Card_Type2).Select(x => new
                  {
                      CardType_Name = x.Key,
                      CardType_Count = x.Sum(y => y.Ration_Card_Count2)
                  })).Union(
                  fpslist.GroupBy(x => x.Ration_Card_Type3).Select(x => new
                  {
                      CardType_Name = x.Key,
                      CardType_Count = x.Sum(y => y.Ration_Card_Count3)
                  })).Union(
                 fpslist.GroupBy(x => x.Ration_Card_Type4).Select(x => new
                 {
                     CardType_Name = x.Key,
                     CardType_Count = x.Sum(y => y.Ration_Card_Count4)
                 })).Union(
                 fpslist.GroupBy(x => x.Ration_Card_Type5).Select(x => new
                 {
                     CardType_Name = x.Key,
                     CardType_Count = x.Sum(y => y.Ration_Card_Count5)
                 }))
                            select g).ToList();
