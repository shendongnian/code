     this.richIndicateText.MouseClick += new MouseEventHandler(richIndicateText_MouseMove); //hook
     this.richIndicateText.MouseClick -= richIndicateText_MouseMove; //unhook
     private void richIndicateText_MouseMove(object sender, MouseEventArgs e)
    {
        richIndicateText.Select(0, 50);
        richIndicateText.SelectionBackColor = Color.Green;
    }
