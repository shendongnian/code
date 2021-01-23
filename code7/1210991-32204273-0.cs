    var countries = CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                        .Select(x => new RegionInfo(x.LCID))
                        .Select(x => new[] { new { Name = x.DisplayName, Code = x.Name },
                                             new { Name = x.NativeName, Code = x.Name }
                                            })
                        .SelectMany(x=>x)
                        .Distinct()
                        .ToDictionary(x => x.Name, x => x.Code);
