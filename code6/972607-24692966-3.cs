            for (int i = 0; i < totalRows; i++)
            {
                foreach (Matrix item in ResultMatrix)
                {
                    if (item.row == i)
                    {
                        for (int j = 0; j < totalColumns; j++)
                            if (item.column == j)
                                richTextBox1.Text += item.value + " ";
                    }
                }
                richTextBox1.Text += Environment.NewLine;
            }
