    private void dataGridView1_DragDrop_1(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(typeof(string)))
        {
            string item = (string)e.Data.GetData(typeof(System.String));
            MessageBox.Show("data is "+ item);
        }
    }
