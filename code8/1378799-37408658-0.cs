    private void tbox_TextChanged(object sender, TextChangedEventArgs e)
    {
        var tb = sender as TextBox;
        if (tb != null)
        {
            var originalText = tb.Text;
    
            var r = new Regex("[^a-zA-Z0-9]+");
            if (originalText != r.Replace(originalText, ""))
            {
                var index = (tb.SelectionStart - 1) < 0 ? 0 : (tb.SelectionStart - 1);
                tb.Text = r.Replace(originalText, "");
                tb.SelectionStart = index;
            }
        }
    }
