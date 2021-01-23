            public bool EnableButton
            {
                set
                {
                    button1.Enabled = value;
                }
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                button1.Enabled = false;
                
                MDIChild child = new MDIChild();
                child.MdiParent = this;
                child.Show();
            }
