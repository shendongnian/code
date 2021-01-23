        private Random rand = new Random();
        private int Index = -1;
        private List<String> Lines = new List<string>();
        private void button1_Click(object sender, EventArgs e)
        {
            string FilePath = @"C:\file.txt";
            if (radioButtonNew.Checked)
            {
                Lines = new List<String>(File.ReadAllLines(FilePath));
                Index = rand.Next(0, Lines.Count);
                label1.Text = "Index: " + Index.ToString();
                TextBox.Text = Lines[Index];
            }
            else if (radioButtonAppend.Checked)
            {
                File.AppendAllText(FilePath, TextBox.Text + Environment.NewLine);
                Lines = new List<String>(File.ReadAllLines(FilePath));
                Index = Lines.Count - 1;
                label1.Text = "Index: " + Index.ToString();
                MessageBox.Show("Line added");
            }
            else if (radioButtonModify.Checked)
            {
                if (Index >= 0 && Index < Lines.Count)
                {
                    Lines[Index] = TextBox.Text;
                    File.WriteAllLines(FilePath, Lines);
                    MessageBox.Show("Line Modified");
                }
                else
                {
                    MessageBox.Show("No Line Selected");
                }
            }
            else if (radioButtonDelete.Checked)
            {
                if (Index >= 0 && Index < Lines.Count)
                {
                    Lines.RemoveAt(Index);
                    File.WriteAllLines(FilePath, Lines);
                    Index = -1;
                    label1.Text = "Index: " + Index.ToString();
                    MessageBox.Show("Line Deleted");
                }
                else
                {
                    MessageBox.Show("No Line Selected");
                }
            }
        }
