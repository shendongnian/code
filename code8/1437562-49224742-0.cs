     EventWaitHandle waitHandle = new EventWaitHandle(true,EventResetMode.AutoReset, "SHARED_BY_ALL_PROCESSES");
        waitHandle.WaitOne();
        int x; //user number
        if (File.Exists("C:\\Users\\Desktop\\Tests\\users5a.txt"))
        {
            var last_number = File.ReadAllLines("C:\\Users\\Desktop\\Tests\\users5a.txt").Last();
            x = int.Parse(last_number) + 1;
        }
        else
            x = 0;
        System.IO.StreamWriter file = new System.IO.StreamWriter("C:\\Users\\Desktop\\Tests\\users5a.txt", true);
        file.WriteLine(x);
        file.Close();
        file.Dispose();
        waitHandle.Set();
