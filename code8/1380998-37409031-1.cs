    private void enumerate_panel_child_contols(Panel pnl)
            {
                _sbtmp.Clear();
                foreach (Control c in pnl.Controls)
                {
                    if (c.GetType() == typeof(Button))
                    {
                        _sbtmp.AppendLine("ButtonName=>" + c.Name);
                    }
                    else if (c.GetType() == typeof(Panel))
                    {
                        enumerate_panel_child_contols((Panel)c);
                        _sbtmp.AppendLine("PanelName=>" + c.Name);
                    }
                }
                var sw = new StreamWriter(Path.GetDirectoryName(Application.ExecutablePath) + "\\" + pnl.Name  + ".txt");
                sw.WriteLine(_sbtmp.ToString());
                sw.Close();
                _sbtmp.Clear();
            }
