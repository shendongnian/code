    private void GetMainAppSettings()
    { 
        MainSetting Item = context.FetchMainAppSettings();
        SliderContext contextSlider = new SliderContext();
        Slider SW = new Slider();
        string PageName = "Home Page";
        IEnumerable<_14Muslims.Domain.Entity.Slider> pType = contextSlider.SliderFetchAllEnabled(PageName);
        rptSlider.DataSource(pType);
        rptSlider.DataBind();
    }
