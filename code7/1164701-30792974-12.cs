        Queue<string> cmdQueue = new Queue<string>();
        static StringBuilder StdOutput = new StringBuilder();
        static StringBuilder ErrOutput = new StringBuilder();
        Process p = null;
        Task processTask = null;
        bool processIsRunning = false;
