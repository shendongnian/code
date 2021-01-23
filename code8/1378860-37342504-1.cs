    int value = 0;
    double average = TextBoxPanel.Controls.OfType<TextBox>() // get all TextBoxes from this panel
        .Where(t => int.TryParse(t.Text, out value))  // which Text is parsable to int
        .Select(t => value)                           // select the value that contains the parsed int
        .Average();                                   // use Enumerable.Average to calculate the average
