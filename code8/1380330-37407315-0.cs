        private void validateTextInteger(object sender, EventArgs e)
        {
            NumberFormatInfo nfi = new CultureInfo("en-IN", false).NumberFormat;
            nfi = (NumberFormatInfo)nfi.Clone();
            nfi.CurrencySymbol = "";
            Exception X = new Exception();
            TextBox T = (TextBox)sender;
            try
            {
                if (T.Text.Trim() != "-")
                {
                    var val = T.Text.Trim();
                    int x=0;
                    val = val.Replace(",", "");
                    if (!(val.Contains(',')))
                    {
                         x = int.Parse(val);
                    }
                    string  s  = string.Format(nfi, "{0:C0}", x);
                    T.Text = s.Trim();
                    T.SelectionStart = T.Text.Length ;
                    T.SelectionLength = 0;
                    return;
                }
            }
            catch (Exception)
            {
                try
                {
                    int CursorIndex = T.SelectionStart - 1;
                    T.Text = T.Text.Remove(CursorIndex, 1);
                    //Align Cursor to same index
                    T.SelectionStart = T.Text.Length;
                    T.SelectionLength = 0;
                }
                catch (Exception)
                { 
                }
            }
        }
