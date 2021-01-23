    for(int i = 0; i < myControl.Controls.Length; i++)
    {
        if(myControl.Controls[i] is TextBox || myControl.Controls[i] is DropDownList || 
           myControl.Controls[i] is RadioButtonList || myControl.Controls[i] is Checkbox)
        {
            var webControl = myControl.Controls[i] as WebControl;
            webControl.CssClass = "my-class";
        }        
    }
