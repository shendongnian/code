    private void copyToolStripMenuItem_Click(object sender, EventArgs e)
    {
      System.Windows.Forms.Control control = this.ActiveControl;
            if (control.GetType() == typeof(System.Windows.Forms.TextBox))
                System.Console.WriteLine(((System.Windows.Forms.TextBox)control).SelectedText);
    }
