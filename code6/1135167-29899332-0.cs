    var Dgates = cc_Db.Dim_Responsibility
            .Select(s => new SelectListItem
              {
                  Value = s.Responsibility_Key.ToString(),
                  Text = s.Responsibility + " - " + s.Level
              }).ToList();
