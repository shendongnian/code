     var etjoin = (from e in dxlXs.AsEnumerable()
                  let temp = e != null ? e.Field<String>("Ip Address").Replace(".","0") : "N/A"
                  join t in tstarresults on temp equals t.DeviceUID
                  into leftjointable
                  from x in leftjointable.DefaultIfEmpty()
                  select new ATTModel
                  {
                      ATTIP = temp,
                      //...
                  }).ToList();
