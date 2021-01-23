    private bool changing;
    private void TextBox_TextChanged(object sender, EventArgs e)
    {
        if (!changing) {
            changing = true;
            try {
                // manipulate entries in the ListBox
            } finally {
                changing = false;
            }
        }
    }
    private void ListBox_IndexChanged(object sender, EventArgs e)
    {
        if (!changing) {
            changing = true;
            try {
                // Put selected entry into TextBox
            } finally {
                changing = false;
            }
        }
    }
    
