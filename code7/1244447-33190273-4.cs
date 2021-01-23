        private void someFunction(int sp)
        {
            int i = 0;
            Func<int, int, int, int> formula = null;
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
                var Obj = List[formula.Invoke(i, sp, globalVar)];//this globalVar can be a gloabl or local var or even a passed param to the method
                //My code here
                i++;
            }
        }
        private int getFormula_1(int index, int pos, int tc)
        {
            return index;
        }
        private int getFormula_2(int index, int pos, int tc)
        {
            return pos - (index * tc); ;
        }
