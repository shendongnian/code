<!-- -->
        private void ContentMenu_Initialized(object sender, EventArgs e)
        {
            NameScope.SetNameScope((ContentElement)sender, NameScope.GetNameScope(this));
        }
