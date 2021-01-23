        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_ProcessMine != null && !_ProcessMine.HasExited)
            {
                // Depending on the type of app:
                _ProcessMine.CloseMainWindow();
                // ... or ...
                _ProcessMine.Kill(); 
            }
        }
