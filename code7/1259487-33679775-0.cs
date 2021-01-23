    public static void SortAndSumTextboxes()
    {
        Form form = new Form();
        var tiControls = form.Controls.OfType<TextBox>().Where(tb => Regex.IsMatch(tb.Name, "^ti.$"));
        var tControls = form.Controls.OfType<TextBox>().Where(tb => Regex.IsMatch(tb.Name, "^t.$"));
        var tiSorted = tiControls.Select(tb => int.Parse(tb.Text)).OrderBy(i => i);
        var tSorted = tControls.Select(tb => int.Parse(tb.Text)).OrderBy(i => i);
        int c = 1; // some constant
        var tfValues = tiSorted.Zip(tSorted, (a, b) => a + b + c).ToArray();
        var tfControls = form.Controls.OfType<TextBox>().Where(tb => tb.Name.StartsWith("tf")).OrderBy(tb => tb.Name).ToArray(); ;
        for (int i = 0; i < tfControls.Length; i++)
        {
            tfControls[i].Text = tfValues[i].ToString();
        }
    }
