            private void button1_Click(object sender, EventArgs e)
            {
                Process pro = new Process();
                pro.StartInfo.FileName = "notepad";
                pro.StartInfo.Arguments = "";
    
                //if you need to do something when the process  exits do this:
                pro.EnableRaisingEvents = true;
                pro.Exited += new EventHandler(pro_Exited);
                pro.Start();
                //pro.WaitForExit();
            }
    
            void pro_Exited(object sender, EventArgs e)
            {
                //do what you need here...
            }
