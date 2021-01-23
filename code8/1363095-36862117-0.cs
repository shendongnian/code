        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            this.Invoke((MethodInvoker)delegate
            {
                e.DrawBackground();
                e.DrawFocusRectangle();
                string MyString = listBox.GetItemText(listBox.Items[e.Index]);
                string stringToFind = searchInput.Text;
                if (!string.IsNullOrEmpty(stringToFind))
                {
                    string[] strings = MyString.Split(new string[] { stringToFind }, StringSplitOptions.None);
                    Rectangle rect = e.Bounds;
                    for (int i=0;i<strings.Length;i++)
                    {
                        string s = strings[i];
                        if (s != "")
                        {
                            int width = (int)e.Graphics.MeasureString(s, e.Font,e.Bounds.Width, StringFormat.GenericTypographic).Width;
                            rect.Width = width;
                            TextRenderer.DrawText(e.Graphics, s, e.Font, new Point(rect.X, rect.Y), listBox.ForeColor);
                            rect.X += width;
                        }
                        if (i < strings.Length - 1)
                        {
                            int width2 = (int)e.Graphics.MeasureString(stringToFind, e.Font, e.Bounds.Width, StringFormat.GenericTypographic).Width;
                            rect.Width = width2;
                            TextRenderer.DrawText(e.Graphics, stringToFind, e.Font, new Point(rect.X, rect.Y), listBox.ForeColor, Color.Yellow);
                            rect.X += width2;
                        }
                    }
                }
                else
                {
                    TextRenderer.DrawText(e.Graphics, MyString, e.Font, new Point(e.Bounds.X, e.Bounds.Y), listBox.ForeColor);
                }
            });
        
        }
