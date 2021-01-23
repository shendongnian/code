        int previouslines = 1;
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int size=textBox2.Font.Height;
            int lineas = textBox2.Lines.Length;
            int newlines = 0;
            if (textBox2.Text.Contains(Environment.NewLine))
            {
                newlines = textBox2.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).Length - 1;
                lineas += newlines - (textBox2.Lines.Length - 1);
            }
            
            for(int line_num= 0;line_num<textBox2.Lines.Length;line_num++)
            {
                if (textBox2.Lines[line_num].Length > 1)
                {
                    int pos1=textBox2.GetFirstCharIndexFromLine(line_num);
                    int pos2= pos1 + textBox2.Lines[line_num].Length-1;
                    int y1 = textBox2.GetPositionFromCharIndex(pos1).Y;
                    int y2 = textBox2.GetPositionFromCharIndex(pos2).Y;
                    if (y1 != y2)
                    {
                        int aux = y2+size;
                        lineas = (aux / size);
                        if (y1 != 1)
                        {
                            lineas++;
                        }
                        
                        lineas += newlines - (textBox2.Lines.Length - 1);
                    }
                }
            }
            if (lineas > previouslines)
            {
                previouslines++;
                textBox2.Height = textBox2.Height + size;
            }
            else if (lineas<previouslines)
            {
                previouslines--;
                textBox2.Height = textBox2.Height - size;
            }
        }
