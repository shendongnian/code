    TextBox[] timeTextBoxes = this.Controls.OfType<TextBox>().Where(txt => txt.Name.StartsWith("lap")).ToArray();
    TimeSpan totalTime = new TimeSpan();
    foreach (TextBox txt in timeTextBoxes)
    {
        TimeSpan time;
        if (TimeSpan.TryParse(txt.Text, out time))
            totalTime.Add(time);
    }
    fullTimeTextBox.Text = totalTime.ToString();
