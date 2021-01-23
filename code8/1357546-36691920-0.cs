    private void button2_Click(object sender, EventArgs e)
        {
            string fileName = (string)ModuleSelectorComboBox.SelectedItem;
            NoteSelectorComboBox.Items.Clear();
            string[] files = Directory.GetFiles(@"C:\Modules\" + (string)ModuleSelectorComboBox.SelectedItem);
            foreach (string file in files)
                NoteSelectorComboBox.Items.Add(Path.GetFileNameWithoutExtension(file));
        }
