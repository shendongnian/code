            private void deactivateButtons()
            {
                foreach(Control c in this.Controls)
                {
                    if(c is Button)
                    { c.Enabled = false; }
                }
            }
