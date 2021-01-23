    public static RefAndTwoInt32Wrappers[] test = new RefAndTwoInt32Wrappers[1];
    static void Main()
    {
        test[0].text = "a";
        test[0].x.x = 1;
        test[0].y.x = 1;
        Console.ReadKey();
    }
   
    0:004> !dumpheap -type Ref
         Address               MT     Size
    0000000003c22c78 000007fe61e8fb58       56    
    0000000003c22d08 000007fe039d3c00       48    
   
    Statistics:
                  MT    Count    TotalSize Class Name
    000007fe039d3c00        1           48 RefAndTwoInt32Wrappers[]
    000007fe61e8fb58        1           56 System.Reflection.RuntimeAssembly
    Total 2 objects
