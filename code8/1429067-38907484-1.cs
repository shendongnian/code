    private void textBox1_DragDrop(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(typeof(System.String)))
        {
            string item = (System.String)e.Data.GetData(typeof(System.String));
            textBox1.SelectedText = item;
        }
    }
