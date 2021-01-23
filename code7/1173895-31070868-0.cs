    var result = (form uso in Context.UserSettingOption
                  join ust in Context.UserSettingType on uso.Type_Id equals ust.Id
                  join usv in Context.UserSettingValue on uso.Id equals usv.Setting_Type_Id into tmpusv
                  from lusv in tmpusv.DefaultIfEmpty()
                  select new
                  {
                     Type = ust.Name, 
                     Option = uso.Name, 
                     Value = lusv != null ? lusv.Value : null
                  }).ToList();
