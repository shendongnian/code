    private void globalKeyThread()
            {
                System.Windows.Forms.Keys keyToCheck = Keys.F12;
    
                while (true)
                {
                    state = Convert.ToInt32(GetAsyncKeyState(keyToCheck));
    
                    if (state == -32767)
                    {
                        // Handle what happens when key is pressed.
                        timer1.Start();
                    }
    
                    Thread.Sleep(10);
                }
            }
