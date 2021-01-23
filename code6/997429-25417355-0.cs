        Panel panel = new Panel();
        panel.Controls.Add(new Button() { Text = "Button 1" });
        panel.Controls.Add(new Button() { Text = "Button 2" });
 
        UltraPopupControlContainer container = new UltraPopupControlContainer();
        container.PopupControl = panel;
 
        ultraDropDownButton1.PopupItem = container;
