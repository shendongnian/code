    foreach (ButtonType button in _ButtonType)
    {
       var Button = ButtonsSettings[button];
       htmlHelper.DevExpress().Button(buttonSettings =>
       {
          buttonSettings.Name = Button.Name;
          buttonSettings.ControlStyle.CssClass = "button";
          buttonSettings.Width = 80;
          buttonSettings.Text = Button.Text;
          buttonSettings.ClientSideEvents.Click = String.Format("function(s, e) {{" + onClick + "(\"{0}\"); pcMessage.Hide();}}", Button.ModelResult);
     }).Render();
     
