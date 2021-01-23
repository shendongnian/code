    private void ValidateWidth(string input)
    {
        float width;
        if(float.TryParse(input, out width))
        {
            if (Width >= 2 && Width <= 20)
            {
                return; // every thing is fine. just leave here.
            }
        }
        // something was wrong. show message.
        
        string Title = "Data Invalid";
        string Msg = "Width Measurement is invalid \n Place enter a value between 2 and 20";
        MessageBox.Show(Msg, Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    }
