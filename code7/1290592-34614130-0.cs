        public static int OpenVisualStudio()
        {
            var devenv = Process.Start("devenv.exe");
            if (devenv == null)
            {
                return 0;
            }
            do
            {
                System.Threading.Thread.Sleep(2000);
                mDte = GetDte(devenv.Id);
            }
            while (mDte == null);
            return devenv.Id;
        }
