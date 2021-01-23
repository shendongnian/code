            public void MainUI.Load(Object sender, Eventargs e)
            {
                if (_spmanager != null && !_spManager.IsOpen)
                    //*write the code here where it opens and starts listening
                    _spmanager.StartListening();
                    //*write the code here where it waits a little bit then 
                    _spmanager.Close();
     }
