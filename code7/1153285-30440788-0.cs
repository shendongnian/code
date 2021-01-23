    tbTest.KeyUp += ((o, e) =>
                {
                    switch (e.Key)
                    {
                        case Key.OemPeriod:
                            #if DEBUG
                            System.Diagnostics.Debug.WriteLine("Period pressed");
                            #endif
                            var tb = (TextBox)o;
                            tb.Text = tb.Text.Replace(".", ","); //Replace period with comma
                            tb.Select(tb.Text.Length, 0);
                            break;
                    }
                });
