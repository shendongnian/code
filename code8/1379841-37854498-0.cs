     private void tb1_KeyDown(object sender, KeyRoutedEventArgs e)
            {
                if (e.Key >= Windows.System.VirtualKey.Number0 && e.Key <= Windows.System.VirtualKey.Number9 || e.Key == Windows.System.VirtualKey.Decimal || e.Key == Windows.System.VirtualKey.GamepadY)
                {
                    string strkey = e.Key.ToString().Substring(e.Key.ToString().Length - 1, e.Key.ToString().Length - (e.Key.ToString().Length - 1));
    
                    if (e.Key >= Windows.System.VirtualKey.Number0 && e.Key <= Windows.System.VirtualKey.Number9)
                    {
    
                        TextBox tb = sender as TextBox;
                        int cursorPosLeft = tb.SelectionStart;
                        int cursorPosRight = tb.SelectionStart + tb.SelectionLength;
                        string result1 = tb.Text.Substring(0, cursorPosLeft) + strkey + tb.Text.Substring(cursorPosRight);
                        string[] parts = result1.Split('.');
                        if (parts.Length > 1)
                        {
                            if (parts[1].Length > 2 || parts.Length > 2)
                            {
                                e.Handled = true;
                            }
                        }
                    }
    
                    if (((TextBox)sender).Text.Contains(".") && e.Key == Windows.System.VirtualKey.Decimal)
                    {
                        e.Handled = true;
                    }
                }
                else
                {
                    e.Handled = true;
                }
    
                if (e.Key >= Windows.System.VirtualKey.A && e.Key <= Windows.System.VirtualKey.Z ||
                        e.Key == Windows.System.VirtualKey.Space)
                {
                    e.Handled = true;
                }
            }
