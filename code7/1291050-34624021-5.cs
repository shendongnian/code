    private string Title = "Data Invalid";
    private string Msg;
    private bool ValidateWidth(string input)
    {
        float width;
        if(float.TryParse(input, out width))
        {
            if (Width >= 2 && Width <= 20)
            {
                return true;
            }
        }
    
        Msg = "Width Measurement is invalid \n Place enter a value between 2 and 20";
        return false;
    }
