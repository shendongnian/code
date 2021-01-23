    using System;
    
    namespace app1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Presult();
            }
    
            private static long Presult()
            {
                long presult;
                try
                {
                    object eqtn = null;
                    char begidx = '\0';
                    int curidx = 0;
                    object eqtnArgs = null;
                    presult = EvalInner(eqtn, new Tuple<int, int>(++begidx, curidx - 1), eqtnArgs);
                }
                catch (Exception e)
                {
                    throw e;
                }
                int result = 0;
                object lastop = null;
                object negateNextNum = null;
                object negateNextOp = null;
                result = evalNewResult(result, lastop, presult, ref negateNextNum, ref negateNextOp);
                // ...
                return presult;
            }
    
            private static int evalNewResult(int result, object lastop, long presult, ref object negateNextNum, ref object negateNextOp)
            {
                return 0;
            }
    
            private static long EvalInner(object eqtn, Tuple<int, int> tuple, object eqtnArgs)
            {
                return 0;
            }
        }
    }
