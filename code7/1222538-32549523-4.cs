    [DllImport(DLL_NAME, CharSet = CharSet.Unicode)]
    public static extern int test(string data_in, int option, int block_size);
    ...
    string fp_template = @"N:/foo/{0}/bar ({1}).csv";
    
    int KB = 1024;
    int MB = KB * 1024;
    
    int block_id = 0;
    foreach (var block_size in new int[] {KB*1,KB*4,KB*32,MB*1,MB*5 })
    {
        Console.WriteLine("BlockSize (KB): " +(block_size/1024));
        for (int i = 0; i < 50; i++)
        {
            Stopwatch sw_loop = Stopwatch.StartNew();
            ParseBlockNative.test(String.Format(fp_template,block_id, i), i % 2,block_size);
            Console.WriteLine("Option: {0} Taken: {1}", i % 2 == 0 ? "0-SLT" : "1-WIN", sw_loop.ElapsedMilliseconds);
        }
        Console.WriteLine();
        block_id++;
    }
