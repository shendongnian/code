    public static int ParseInput(string inInt)
    {
        try
        {
            int input = int.Parse(inInt);
            return input;
        }
        catch (FormatException e)
        {
            throw new CustomException("Format error!", e);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Use only numbers! " + ex.Message);
            return -1;
        }
    }
