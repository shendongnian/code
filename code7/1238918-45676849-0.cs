    private void Form1_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
    {
      // for this program, we allow a file to be dropped from Explorer
      if (e.Data.GetDataPresent(DataFormats.FileDrop))
      {  e.Effect = DragDropEffects.Copy;}
      //    or this tells us if it is an Outlook attachment drop
      else if (e.Data.GetDataPresent("FileGroupDescriptor"))
      {  e.Effect = DragDropEffects.Copy;}
      //    or none of the above
      else
      {  e.Effect = DragDropEffects.None;}
    }
