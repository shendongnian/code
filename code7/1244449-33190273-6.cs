        private void someFunction(int sp)
        {
            int i = 0;
            Func<int[], int> formula = null;
            switch (f)
            {
                case 1:
                {
                    formula = getFormula_1;
                }
                break;
                case 2:
                {
                    formula = getFormula_2;
                }
                break;
            }
            i = startIndex;
            while (i < endIndex)
            {
                int[] intValues = new int[] {i,sp,globalVar };
                var Obj = List[formula.Invoke(intValues)];
                //My code here
                i++;
            }
        }
        private int getFormula_1(params int[] intValues)
        {
            return intValues[0];
        }
        private int getIndex_Vertical(params int[] intValues)
        {
            return intValues[1] - (intValues[0] * intValues[2]); 
        }
