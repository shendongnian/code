    IEnumerable<SelectListItem> itemCollection = 
       context.Countries
              .AsEnumerable()
              .Select(item => new SelectListItem
              {
                  Text = item.CountryName,
                  Value = item.CountryId.ToString()
              });
