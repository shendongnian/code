    string[] colours = new string[]{"Red","Green","Blue","Yellow","etc"};//These would be the values in your combobox dropdown list.
    Color selectedcolour;
    private void ComboBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)//If enter key pressed.
        {
            if (colours.Contains(ComboBox.Text))//If the colour is one of the default colours.
            {
                selectedcolour = Color.FromName(ComboBox.Text);
            }
            else
            {
                List<string> parts = ComboBox.Text.Split(';');//Split text into parts between each ";".
                foreach(string part in parts)
                {
                    if (part == "")
                    {
                        parts.Remove(part);
                    }
                }
                int r = int.Parse(parts[0]);
                int g = int.Parse(parts[1]);
                int b = int.Parse(parts[2]);
                selectedcolour = Color.FromArgb(r,g,b);
            }
            exampleProcess(selectedcolour);
        }
    }
