    if (themeedit == 1)
                {
                    String txt = Themecb.SelectedText;
                    TextBox1.Text = "THEME WORK " + txt;
                    Tuple<AppTheme, Accent> appStyle = ThemeManager.DetectAppStyle(Application.Current);
                    ThemeManager.ChangeAppStyle(Application.Current,
                                                ThemeManager.GetAccent(txt),
                                                ThemeManager.GetAppTheme("BaseLight")); // or appStyle.Item1
                }
