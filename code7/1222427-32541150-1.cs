    public static int ParseInput(string inInt)
    {
        int input;
        if (!int.TryParse(inInt, out input)) MessageBox.Show("Only use numbers!");
        return input;
    }
