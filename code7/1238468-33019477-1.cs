     //THIS IS THE FOR, THAT LOCKS THE COLUMN 0 and 1 ************
            for (int j = 0; j <= (i - 1); j++)
            {
                if (j == 0)
                {
                    e.Row.Cells[j].CssClass = "pinned col1";
                }
                else if (j == 1)
                {
                    e.Row.Cells[j].CssClass = "pinned col2";
                }
                else
                {
                    e.Row.Cells[j].CssClass = "scrolled";
                }
            }
    //********************************
