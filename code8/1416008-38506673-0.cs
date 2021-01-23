    List<System.Windows.Forms.TextBox> all_cycles = new List<System.Windows.Forms.TextBox>(10);
            int[] indexOfTextBox = new int[3];
            foreach(var cycle in all_cycles)
            {
                int value = Convert.ToInt16(cycle.Text);
                if (value > indexOfTextBox[0])
                {
                    indexOfTextBox[0] = value;
                }
                else if (value > indexOfTextBox[1])
                {
                    indexOfTextBox[1] = value;
                }
                else if (value > indexOfTextBox[2])
                {
                    indexOfTextBox[2] = value;
                }
            }
            all_cycles[indexOfTextBox[0]].BackColor = ConsoleColor.Red;
            all_cycles[indexOfTextBox[1]].BackColor = ConsoleColor.Blue;
            all_cycles[indexOfTextBox[2]].BackColor = ConsoleColor.Green;
