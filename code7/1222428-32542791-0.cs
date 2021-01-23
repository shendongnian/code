    public static int ParseInmatning(string inInt)
    {
        try
        {
            int input = int.Parse(inInt);
            return input;
            throw new CustomException("Wrong format");
        }
        catch (FormatException e)
        {
            MessageBox.Show("Only use numbers! " + e.Message, "ERROR!");
            return -1;
        }
    }
