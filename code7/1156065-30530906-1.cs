    var lvg = LowerVehicles.GroupBy(t => t.vserial)
                           .Select(g => new { 
                                               VSerial = g.Key, 
                                               MaxUpdatedOn = g.Max(t => t.updatedOn) 
                                            });
    var query = LowerVehicles.Join( 
                                    lvg, 
                                    a => new { a.VSerial, a.updatedOn }, 
                                    b => new { b.VSerial, b.MaxUpdatedOn }, 
                                    (a, b) => new { LV = a, LVG = b}
                                  )
                             .Select(t=> t.LV);
