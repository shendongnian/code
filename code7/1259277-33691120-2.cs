    if (vm.FilterProdCountry[0].IsSelected)
    {
        foreach (Filter filter in vm.FilterProdCountry.Skip(1))
        {
            filter.IsSelected = false;
        }
    }
