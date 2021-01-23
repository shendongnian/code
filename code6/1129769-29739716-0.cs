        ....
        TabPage tp = new TabPage("New Document");
        RichTextBox rtb = new RichTextBox();
        rtb.Dock = DockStyle.Fill;
        //Add listener
        rtb.MouseClick += new MouseEventHandler(Control1_MouseClick);
        tp.Controls.Add(rtb);
        tabControl1.TabPages.Add(tp);    
        ...
    }
    private void Control1_MouseClick(Object sender, MouseEventArgs e) {
        //Stuff
    }
