    private static int CellReferenceToIndex(Cell cell)
    {
        int index = 0;
        string reference = cell.CellReference.ToString().ToUpper();
        foreach (char ch in reference)
        {
            if (Char.IsLetter(ch))
            {
                int value = (int)ch - (int)'A';
                index = (index == 0) ? value : ((index + 1) * 26) + value;
            }
            else
            {
                return index;
            }
        }
        return index;
    }
