     public static IEnumerable<SelectListItem> GetSelectListItems<T>(string defaultValue)
     {
          if(!typeof(T).IsEnum)
            throw new Exception("Not an enum");
    
          yield return new SelectListItem
          {
              Text = defaultValue,
              Value = string.Empty
          };
    
          foreach(var item in Enum.GetValues(typeof(T)))
          {
               yield return new SelectListItem
               {
                    Text = SiteUtilities.GetEnumDescription((Enum)item),
                    Value = Convert.ChangeType(item, typeof(T).GetEnumUnderlyingType().ToString()) // not all enums are int's
               }
          }
     }
