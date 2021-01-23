    var Dgates = cc_Db.Dim_Responsibility.Select(new{
                  Value = s.Responsibility_Key,
                  Text = s.Responsibility + " - " + s.Level
    }).ToList().Select(a => new SelectListItem
              {
                  Value = a.Value.ToString(),
                  Text = a.Text
              }).ToList();
