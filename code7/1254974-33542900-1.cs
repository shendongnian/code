    public List<DateViewModel> DateCustomViewModels
    {
        get
        {
            return CustomFieldViewModels.OfType<DateViewModel>().ToList()
        }
    }
