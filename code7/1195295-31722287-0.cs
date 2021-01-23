    private void btnDarkBlue_Click(object sender, EventArgs e)
    {
        rich1.SelectionColor = Color.DarkBlue;
        rich2.SelectionStart = rich1.SelectionStart;
        rich2.SelectionLength = 0;
        rich2.SelectedText = whateverTextYouLike;
        rich2.SelectionColor = Color.DarkBlue; //<-- apply any format if you like only after setting selected text
    }
