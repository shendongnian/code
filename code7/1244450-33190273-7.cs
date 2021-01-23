            int i = -1;
            Func<int,int> formula = null;
            switch(f)
            {
                case 1:
                {
                    formula = new Func<int,int>(index => { return i; });
                }
                break;
                case 2:
                {
                    formula = new Func<int, int>( index => { return s- (i * c); } );//here s and c are global variables.
                }
                break;
            }
            i = startIndex;
            while(i < endIndex)
            {
                var Obj= List[formula.Invoke(i)];
                //my code goes here
                i++;
            }
