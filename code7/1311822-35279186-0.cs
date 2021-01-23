    private void ConditionallyHighlight(double cellVal, int rowIndex)
    {
        int COL_K_INDEX = 11;
        if (cellVal > delsPerWeek)
        {
            Excel.Range cellToHighlight = (Excel.Range)_xlSheet.Cells[rowIndex,
                COL_K_INDEX];
            cellToHighlight.Interior.Color = OUT_OF_BOUNDS_HIGHLIGHT_COLOR;
        }
    }
