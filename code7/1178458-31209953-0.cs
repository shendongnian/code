    if (!isInternalChange)
    {
        if (e.PropertyName == "Data")
        {
            await GetValueDate(e);
        }
        else if (e.PropertyName == "QtaDiv1" || e.PropertyName == "Exchange")
        {
            isInternalChange = true;
            ChangeQtaDiv2(QtaDiv1, Exchange);
            isInternalChange = false;
        }
        if (e.PropertyName == "QtaDiv2")
        {
            isInternalChange = true;
            ChangeQtaDiv1(QtaDiv2, Exchange);
            isInternalChange = false;
        }
        else if (e.PropertyName == "SelectedCross")
        {
            await GetValueDate(e);
            CheckForSplitVisibility();
        }
        base.OnPropertyChanged(e);
    }
