    foreach (string item in listBox1.Items)
            {                   
                string service = item.Substring(0,item.Length-3);
                string price = item.Substring(item.Length - 3, 3);
                {
                    e.Graphics.DrawString(service, new Font("Courier New", 12, FontStyle.Italic), new SolidBrush(Color.Black), 10, 10 + offset);
                    e.Graphics.DrawString("".PadRight(14)+price, new Font("Courier New", 12, FontStyle.Italic), new SolidBrush(Color.Black), 10, 10 + offset);
                    offset = offset + (int)fontHeight + 5;
                }
            }
