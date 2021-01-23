    void ICallbackEventHandler.RaiseCallbackEvent(string eventArgument)
    {
       MyControl c1 = (MyControl)page.LoadControl("/Controls/myControl.ascx");
       c1.InitializeWithValue = Person.Enum.Employee; //<--CRASH
    
       System.Text.StringBuilder sb = new System.Text.StringBuilder();
       System.IO.StringWriter sw = new System.IO.StringWriter(sb);
       HtmlTextWriter hw = new HtmlTextWriter(sw);
       c1.RenderControl(hw);
       return sb.ToString();
    }
