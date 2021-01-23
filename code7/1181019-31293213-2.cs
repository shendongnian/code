<!-- -->
        private void ContextMenu_Initialized(object sender, EventArgs e)
        {
            NameScope.SetNameScope((ContextMenu)sender, NameScope.GetNameScope(this));
        }
