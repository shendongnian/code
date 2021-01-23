    protected void TimerTickMethod()
    {
       if (!IsShowALARMFormOpened())
       {
          ShowALARM frm = new ShowALARM();
          frm.Show();
       }
    }
    
    protected bool IsShowALARMFormOpened()
    {
        return Application.OpenForms.OfType<ShowALARM>().Any();
    }
