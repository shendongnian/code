    void EnsureNumbers(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab)
            {
                return; 
            }
            bool result =  EnsureDecimalPlaces();
            if (result == false)
            {
                var thisKeyStr = "";
                if (e.PlatformKeyCode == 190 || e.PlatformKeyCode == 110)
                {
                    thisKeyStr = ".";
                }
                else
                {
                    thisKeyStr = e.Key.ToString().Replace("D", "").Replace("NumPad", "");
                }
                var s = (sender as TextBox).Text + thisKeyStr;
                var rStr = "^[0-9]+[.]?[0-9]*$";
                var r = new Regex(rStr, RegexOptions.IgnoreCase);
                e.Handled = !r.IsMatch(s);
            }
            else
            {
                e.Handled = true;
            }
        }
