        Int64 previous;
        for (int i = 0; i < intermediate.Count; i++)
        {
            if (i == 0)
            {
                previous = intermediate[i].Amt1;
                intermediate[i].Amt1 = newAmountDo.newAmt;
            }
            else
            {
                Int64 temp = intermediate[i].Amt1;
                intermediate[i].Amt1 = previous;
                previous = temp;
            }
        }
