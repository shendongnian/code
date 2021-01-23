    Control ctrl;
    void MyContextMS_Opening(object sender, CancelEventArgs e) {
      ctrl = ((ContextMenuStrip)sender).SourceControl;
    }
    private void SeeDetailsToolStripMenuItem_Click(object sender, EventArgs e) {
      Button b = ctrl as Button;
      if (b != null) {
        MessageBox.Show(b.Text);
      }
    }
