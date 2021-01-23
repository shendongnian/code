    if (displayedData == false)
    {
    
        for (t = 0; t <= 100; t++)
        {
            progressBar1.Value = t;
    
        }
    }
    else
    {
         progressBar1.Value = 200;
         waitlbl.Hide();
         progressBar1.Hide();
    }
