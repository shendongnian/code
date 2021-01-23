    private void disableButtons()
    {
        try
        {
            foreach (Control c in Controls)
            {
                Button b = c as Button;
                if(b != null)
                    b.Enabled = false;
            }
        }
        catch (Exception e) 
        { 
            Console.Writeline(e.ToString());
        }
    } 
