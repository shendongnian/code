            TabControl TC = new TabControl();
            // ... setup the TabControl ...
            TC.Dock = DockStyle.Fill;
            panel1.Controls.Add(TC); // add the TabControl to some kind of container
            TabPage admin = new TabPage("Admin");
            // ... add controls to the "admin" TabPage ...
            TC.TabPages.Add(admin); // add the TabPage to our TabControl
