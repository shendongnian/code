    if (string.IsNullOrEmpty(textbookID.Text))
    {
        MessageBox.Show("Selection Error.");
    }
    else
    {
        MessageBox.Show("Successfully returned", "Book Details", MessageBoxButtons.OK, MessageBoxIcon.Information); 
    }
