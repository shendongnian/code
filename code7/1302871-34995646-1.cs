    this.panel1.MouseHover += new System.EventHandler(this.panel1_MouseHover);
 
    private void panel1_MouseHover(object sender, System.EventArgs e) 
            {
                // Update the mouse event label to indicate the MouseHover event occurred.
                label1.Text = sender.GetType().ToString() + ": MouseHover";
   
     // Instead of printing you can do whatever you want here, like you want to select some text or whatever
                    }
