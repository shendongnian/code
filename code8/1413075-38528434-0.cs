        private void StartClipListening()
        {
            var clites = new CBForm();
            clites.Start_Lintening(this);
            clites.Show();
        }
        private void StarttwoTasks(string path2Sikuli, string path2Scripts, SikuliVariables SikVars)
        {
            StartClipListening();           
            new Thread(() => executeScripts(path2Sikuli, path2Scripts, SikVars)).Start();
            new Thread(() => waitforthat###()).Start();
        }
        private void waitforthat###()
        {
            SuccFailEvent.WaitOne();
            SuccFailEvent.Reset();
        }
