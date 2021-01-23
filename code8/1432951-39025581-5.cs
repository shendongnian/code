    private Omotnica GetValues()
    {
        var o = new Omotnica();
        if (!Int32.TryParse(textBoxNumber.Text, out o.Number)) {
            return null;
        }
        if(String.IsNullOrWhiteSpace(textBoxName.Text)) {
            return null;
        }
        o.Name = textBoxName.Text;
        ... and so on
    }
