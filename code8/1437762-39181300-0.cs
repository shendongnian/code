    protected override void EditText(object sender, TextChangedEventArgs args)
        {
            Entry e = sender as Entry;
            String val = e.Text;
            if (string.IsNullOrEmpty(val))
                return;
            foreach (char c in BannedCharacters)
            {
                if (val[val.Length - 1] == c)
                {
                    val = val.Remove(val.Length - 1);
                    e.Text = val;
                    return;
                }
            }
            base.EditText(sender, args);
        }
