        object oSel = Globals.ThisAddIn.Application.Selection;
        if ((oSel as Excel.Range) != null)
        {
            Excel.Range rngSelection = (Excel.Range)oSel;
            object[,] data = rngSelection.Value2;
            int rank = data.Rank;
            int lbound = data.GetLowerBound(rank-1);
            int ubound = data.GetUpperBound(rank-1);
            for (int i = 1; i <= rank; i++)
            {
                for (int l = lbound; l <= ubound; l++)
                {
                    System.Diagnostics.Debug.Print(data[i,l].ToString());
                }
            }
        }
