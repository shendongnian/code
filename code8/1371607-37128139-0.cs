    static int CalcFine(DateTime returnedOn, DateTime dueOn)
        {
            
            TimeSpan dateDiff = (returnedOn - dueOn);
            int TotalDays = dateDiff.Days;
            if (TotalDays >= 365)
            {
                return 10000;
            }
            else if(TotalDays < 365 && TotalDays > 30 && TotalDays % 30 > 1)
            {
                return (500 * (TotalDays % 30));
            }
            else if(TotalDays < 30 && TotalDays > 0)
            {
                return 15 * TotalDays;
            }
            else
            {
                return 0;
            }
        }
