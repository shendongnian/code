    // I prefer to move these outside the query for clarity.
    var raPlus = ra.Value.AddMinute(1);
    var raMinus = ra.Value.AddMinute(-1);
    var decPlus = dec.Value.AddMinute(1);
    var decMinus = dec.Value.AddMinute(-1);
    var targets = from item in db.Targets
                  where item.RightAscension <= raPlus &&
                        item.RightAscension >= raMinus &&
                        item.Declination <= decPlus &&
                        item.Declination >= decMinus
                  select item;
