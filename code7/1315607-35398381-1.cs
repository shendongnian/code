    private void DragEnterHandler(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormats.Text))
        {
            e.Effect = DragDropEffects.Move;
        }
        else
        {
            e.Effect = DragDropEffects.None;
        }
    }
    private void DragDropHandler(object sender, DragEventArgs e)
    {
        var textData = e.Data.GetData(DataFormats.Text) as string;
        if (textData == null)
            return;
        MessageBox.Show(textData);
        // Validate the URL in textData here
    }
