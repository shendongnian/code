            string output = "";
            Int32[] array = new Int32[3] { 25, 4, 1 };
            int rows = array[0];
            int cols = array[1];
            int op = array[2];
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    int value = 0;
                    string opStr = "";
                    if (op == 1) // +
                    {
                        opStr = "+";
                        value = r + c;
                    }
                    else if (op == 2) // -
                    {
                        opStr = "-";
                        value = r - c;
                    }
                    else if (op == 3) // *
                    {
                        opStr = "*";
                        value = r * c;
                    }
                    // ...
                    output += string.Format("{0} {1} {2} = {3}\t", r, opStr, c, value);
                }
                output += System.Environment.NewLine;
            }
            System.Console.Write(output);
            System.Diagnostics.Debug.Write(output);
            textarea.Text = output;
