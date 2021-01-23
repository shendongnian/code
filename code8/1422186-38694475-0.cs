    foreach (var tehsil in monitor.Tehsils)
                {
                    var ordered = tehsil.Schools.OrderBy(x => x.Distance).ToList();
   		            var maxmin = new List<tehsil.Schools>{ordered.FirstOrDefault(), ordered.LastOrDefault()}
                    tehsil.Schools = maxmin;
                }
