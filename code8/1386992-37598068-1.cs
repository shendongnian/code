    protected void Page_Load(object sender, EventArgs e)
            {
    switch (strClicked)
                {
                    case "Tab1" :
                        Tab1.CssClass = "Clicked";
                        Tab2.CssClass = "Initial";
                        Tab3.CssClass = "Initial";
                        Tab4.CssClass = "Initial";
                        Tab5.CssClass = "Initial";
                        Tab6.CssClass = "Initial";
                        MainView.ActiveViewIndex = 0;
                        break;
                    case "Tab2" :
                        Tab1.CssClass = "Initial";
                        Tab2.CssClass = "Clicked";
                        Tab3.CssClass = "Initial";
                        Tab4.CssClass = "Initial";
                        Tab5.CssClass = "Initial";
                        Tab6.CssClass = "Initial";
                        MainView.ActiveViewIndex = 1;
                        break;
                    case "Tab3" :
                        Tab1.CssClass = "Initial";
                        Tab2.CssClass = "Initial";
                        Tab3.CssClass = "Clicked";
                        Tab4.CssClass = "Initial";
                        Tab5.CssClass = "Initial";
                        Tab6.CssClass = "Initial";
                        MainView.ActiveViewIndex = 2;
                        break;
                    default :
                        break;
    
                }
    }
