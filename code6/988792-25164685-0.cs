     void txtBox_TextChanged(object sender, EventArgs e)
            {
                TextBox Sender = (TextBox)sender;
                if (Sender.Text == Sender.Attributes["OriginalValue"])
                    Sender.ForeColor = System.Drawing.Color.Black;
                else
                {
                    Sender.ForeColor = System.Drawing.Color.Blue;
                    if (Session["MyData"] != null)
                    {
                        List<string> _ss = (List<string>)Session["MyData"];
                        //_ss.Find(a => a == Sender.Attributes["OriginalValue"]);
                        _ss.Remove(Sender.Attributes["OriginalValue"]);
                        _ss.Add(Sender.Text);
                    }
                }
            }
