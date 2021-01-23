    Hashtable myHashtable;
        private void Get_Already_Running_Excel()
        {
            Process[] AllProcesses = Process.GetProcessesByName("excel");
            myHashtable = new Hashtable();
            int iCount = 0;
            foreach (Process ExcelProcess in AllProcesses)
            {
                myHashtable.Add(ExcelProcess.Id, iCount);
                iCount = iCount + 1;
            }
        }
        public void Close_User_Excel()
        {
            Process[] AllProcesses = Process.GetProcessesByName("excel");	    
            // check to kill the right process
            foreach (Process ExcelProcess in AllProcesses)
            {
                if (myHashtable.ContainsKey(ExcelProcess.Id) == false)
                { ExcelProcess.Kill(); }
            }
            AllProcesses = null;
        }
