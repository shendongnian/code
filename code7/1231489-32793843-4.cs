    void SetTheme()
    {
        foreach (Theme theme in MainViewModel.Themes)
        {
            if (theme != this)
            {
                theme.Checked = false;
            }
        }
    
        // Do actual theme setting .
    }
