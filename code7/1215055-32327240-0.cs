        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            var page = e.Control as TabPage;
            if (page != null)
            {
                page.UseVisualStyleBackColor = false;
                page.BackColor = Color.Red;
            }
        }
    }
