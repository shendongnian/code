        protected void Tab3_Click(object sender, EventArgs e)
        {
            Page.Validate("YourValidationGroup");
            if (Page.IsValid)
            {
                Tab1.CssClass = "Initial";
                Tab2.CssClass = "Initial";
                Tab3.CssClass = "Clicked";
                MainView.ActiveViewIndex = 2;
            }
        }
