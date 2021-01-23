    Process[] oldProcesses = { };
        int clicked = 0;
    
        private void button1_Click_1(object sender, EventArgs e)
        {           
            Process[] newProcesses;
            if (clicked == 0)
            {
                oldProcesses = newProcesses = Process.GetProcesses();            
                clicked = 1;
            }
            else
            {
                newProcesses = Process.GetProcesses();
            }
            Console.WriteLine("Old: " + oldProcesses.Count());
            Console.WriteLine("New: " + newProcesses.Count());
    
            var Difference = newProcesses.Except(oldProcesses).ToList();
            Console.WriteLine("Diff: " + Difference.Count());
    
    
            string allproc = "";
            foreach(Process theprocess in oldProcesses)
            {
                allproc += theprocess.ProcessName.ToString() +"\n";
            }
            MessageBox.Show(allproc);
    
            allproc = "";
            foreach (Process theprocess in newProcesses)
            {
                allproc += theprocess.ProcessName.ToString() + "\n";
            }
            MessageBox.Show(allproc);
    
    
            allproc = "";
            foreach (Process theprocess in Difference)
            {
                allproc += theprocess.ProcessName.ToString() + "\n";
            }
            MessageBox.Show(allproc);
    
    
            /*Process[] processlist = Process.GetProcesses();
            string ProcList = "";
            string temp;
            foreach (Process theprocess in processlist)
            {
                temp = theprocess.ProcessName.ToString() + "\n";
                ProcList += temp;
            }*/
        }
