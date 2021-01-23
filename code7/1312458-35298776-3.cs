    public List<CustomerWidget> SearchWidgets(string surname, string firstname, string ZipCode)
    {
        var widgetSearchResults = _context.CustomerWidgets.Where(x => x.IsDeleted == false);
        if (!string.IsNullOrEmpty(surname))
        {
            widgetSearchResults =
                widgetSearchResults.Where(x => x.Surname.ToUpper().Contains(surname.ToUpper()));
        }
        if (!string.IsNullOrEmpty(firstname))
        {
            widgetSearchResults =
                widgetSearchResults.Where(x => x.Forename.ToUpper().Contains(firstname.ToUpper()));
        }
        if (!string.IsNullOrEmpty(ZipCode))
        {
            widgetSearchResults =
                widgetSearchResults.Where(
                    x => x.ZipCode.Replace(" ", "").ToUpper().Contains(ZipCode.Replace(" ", "").ToUpper()));
        }
        /********************
          Call ToList() only here
          *******************/
      
        return widgetSearchResults.ToList();
    }
