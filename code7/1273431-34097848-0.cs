            string textBox1 = //text from text box 1
            string output = "";
            string[] s = textBox1.Split(' ');
            int itemsSorted = 0;
            while (true)
            {
                itemsSorted = 0;
                for (int i = 0; i < s.Length-1; i++)
                {
                    if(s[i].Length > s[i+1].Length)
                    {
                        string temp = s[i];
                        s[i] = s[i + 1];
                        s[i + 1] = temp;
                        itemsSorted++;
                    }
                }
                if (itemsSorted == 0)
                    break;
            }
            
            for(int i = 0;i < s.Length;i++)
            {
                output += s[i] + " ";
            }
            //trim trailing space if you would like
            //text box 2 text set to = output
