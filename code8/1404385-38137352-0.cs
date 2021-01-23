    public int numberOfPositives()
        {
            foreach (myRowClass row in myDataBase.GetTable<myRowClass>())
            {
                if (row.lastColumn > 0) return (int)Math.Round(1 / row.lastColumn,0);
            }
            return 0;
        }
