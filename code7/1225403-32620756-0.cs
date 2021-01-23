     for (int i = GetSmallerNumber(firstNumber, secondNumber); i < GetLargerNumber(firstNumber, secondNumber); i++)
            {
                numberTotal +=i;
            }
            
    public Int32 GetSmallerNumber(Int32 Number1, Int32 Number2)
        {
            if (Number1 < Number2)
                return Number1;
            else
                return Number2;
         }
     public Int32 GetLargerNumber(Int32 Number1, Int32 Number2)
        {
            if (Number1 < Number2)
                return Number2;
            else
                return Number1;
        }
