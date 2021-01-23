    bool bSave = false;
    public void OnSelectedChange_OneDatagrid(Object sender, RoutedEventArgs e)
    { 
        if(bSave)
        {
            // You can make the treatment
        }
        else
        {
            bSave = false;
        }
    }
    public void OnSelectedChange_TwoDatagrid(Object sender, RoutedEventArgs e)
    { 
        if(!bSave)
        {
            // You can make the treatment
        }
        else
        {
            bSave = true;
        }
    }
