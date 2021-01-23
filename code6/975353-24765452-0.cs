    private void listBox2_DragDrop(object sender, DragEventArgs e) {
      string dragItem = e.Data.GetData(DataFormats.Text) as string;
      if (dragItem != null && !listBox2.Items.Contains(dragItem)) {
        listBox2.Items.Add(dragItem);
        listBox1.Items.Remove(dragItem);
      }
    }
    private void listBox1_DragDrop(object sender, DragEventArgs e) {
      string dragItem = e.Data.GetData(DataFormats.Text) as string;
      if (dragItem != null && !listBox1.Items.Contains(dragItem)) {
        listBox1.Items.Add(dragItem);
        listBox2.Items.Remove(dragItem);
      }
    }
