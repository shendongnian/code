            StringBuilder strb = new StringBuilder();
            for (int i = 0; i < lines.Length; i++)
            {
                strb.Append(lines[i] + "\n");
            }
            richEditControl1.Text = strb.ToString();
