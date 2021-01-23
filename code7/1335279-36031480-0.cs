    var iconattrs = new Dictionary<string, string>
                    {
                        {"ITEMTYPE", "DIVESITE"},
                        {"LOCATION", diveSite.Location},
                        {"DESCRIPTION", diveSite.BriefDescription},
                        {"LINK", diveSite.Link},
                        {"ID", diveSite.ID.ToString()}
                    };
     var myResult = NSDictionary.FromObjectsAndKeys(iconattrs.Values.ToArray()
                                                   ,iconattrs.Keys.ToArray())
