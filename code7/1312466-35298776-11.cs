        if (!string.IsNullOrEmpty(ZipCode))
        {
            ZipCode = ZipCode.Replace(" ", "");
            widgetSearchResults =
                widgetSearchResults.Where(
                    x => x.ZipCode.Replace(" ", "").ToUpper().Contains(ZipCode.ToUpper()));
        }
