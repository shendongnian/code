    public List<SelectListItem> Getallcountries()
    {
       
        using (var db = new DatabaseContext())
        {
            var countrylist = db.Countries.Where(x => x.IsActive == true).ToList().Select(x => new SelectListItem
            {
                Text = x.CountryName,
                Value = Convert.ToString(x.ID)
            });
    
           return  countrylist.ToList();
        }
        
    }
