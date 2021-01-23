    public IEnumerable<SelectListItem> CountryList 
     {
        get
        {
            var _countryList = new List<SelectListItem>();
            foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.AllCultures & CultureTypes.NeutralCultures))
            {
                RegionInfo ri = new RegionInfo(ci.LCID);
                var selectListItem = new SelectListItem();
                selectListItem.Value = ci.LCID.ToString(); //Value of the object, should be unique
                selectListItem.Text = ri.EnglishName; //Text that will be displayed
                _countryList.Add(selectListItem);
            }
            return _countryList;
        }
    }
