     private void dataGridView1_MouseClick(Object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu cm = new ContextMenu();
                this.ContextMenu = cm;
                cm.MenuItems.Add(new MenuItem("&Cut", new System.EventHandler(this.cut_Click)));
                cm.MenuItems.Add(new MenuItem("&Copy", new System.EventHandler(this.copy2_Click)));
                cm.MenuItems.Add(new MenuItem("&Paste", new System.EventHandler(this.paste2_Click)));
                
                cm.Show(this, new Point(e.X, e.Y));
            }
        }
