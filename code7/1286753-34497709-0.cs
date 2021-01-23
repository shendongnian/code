    private int[] numCols = null;
    public int[] NumCols
    {
        get
        {
            if (numCols == null)
            {
                numCols = ExpensiveCalculation();
            }
            return numCols;
        }
    }
