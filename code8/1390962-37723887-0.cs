        private void Button1Click(object sender, EventArgs e) {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save As";
            saveFileDialog.Filter = "Text File (*.txt)|*.txt";
            saveFileDialog.InitialDirectory = @"C:\";
            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create);
                using (StreamWriter objWriter = new StreamWriter(fs)) {
                    for (int i = 0; i < GetMaxRows(); i++) {
                        objWriter.WriteLine("\"{0}\"\t\"{1}\"\t\"{2}\"", GetText(i, 0), GetText(i, 1), GetText(i, 2));
                    }
                }
                MessageBox.Show("SAVED");
            }
        }
        private int GetMaxRows() {
            return Math.Max(Math.Max(textBox1.Lines.Length, textBox2.Lines.Length), textBox3.Lines.Length);
        }
        private string GetText(int row, int textboxId) {
            switch (textboxId) {
                case 0:
                    return textBox1.Lines.Length > row ? textBox1.Lines[row] : string.Empty;
                case 1:
                    return textBox2.Lines.Length > row ? textBox2.Lines[row] : string.Empty;
                case 2:
                    return textBox3.Lines.Length > row ? textBox3.Lines[row] : string.Empty;
                default:
                    throw new Exception("Not a valid id");
            }
        }
