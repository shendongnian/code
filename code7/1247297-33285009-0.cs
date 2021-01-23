     foreach ( string ex in ar)
            {
                if (Regex.IsMatch(txtbox.Text, @"^(www\.)([\w]+)\.(" + ex + ")$"))
                {
                    lbl.Text = "True";
                    return;
                }
                else
                {
                    lbl.Text = "False";
                }
            }
