     for (int a = 0; a < 20;a++ )
            {
                RichTextBox textBox = new RichTextBox();
                TextBoxes[a] = textBox;
                TabPage tabPage = new TabPage();
                TabPages[a] = tabPage;
            }
                for (int x = 0; x < 19; x++)
                {
                    TabPages[x].Controls.Add(t);    
                    TabControl.TabPages.Add(TabPages[x]);
                }
