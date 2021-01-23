    public static void Do(Int32 param1, Int32 param2)
    {            
        Int32 loopI;
        Int32 outBefore, 
            outAfter,
            outGoto1 = 0,
            outGoto2 = 0;
        Int32[] outValues = new Int32[7];
        Console.WriteLine("METHOD:");
            
        Console.WriteLine("DoBeforeLoop");
        outBefore = param1 + param2;
        Boolean wasInGoto2 = false;
        for (loopI = 0; loopI < 7; loopI++)
        {
            Console.WriteLine("Iteration {0}", loopI);
            Console.WriteLine("FortranLoopMethodState.LoopCycleStart");
            outValues[loopI] = loopI;
                
        goto1:
            Console.WriteLine("FortranLoopMethodState.Goto1");
            outGoto1 = loopI + param1;
            if (wasInGoto2)
            {
                wasInGoto2 = false;
                goto end;
            }
                
            wasInGoto2 = true;
            Console.WriteLine("FortranLoopMethodState.Goto2");
            outGoto2 = loopI + param2;
            goto goto1;
        end:
            DoNothing(); // We don't use break, do we?
        }
        Console.WriteLine("DoAfterLoop");
        outAfter = param1 - param2;
            
        Console.WriteLine(outGoto1);
        Console.WriteLine(outGoto2);
    }
