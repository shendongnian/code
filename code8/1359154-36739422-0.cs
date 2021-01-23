            public void MainUI.Load(Object sender, Eventargs e)
            {
                if (_spmanager != null && _spManager.IsOpen)
                    _spmanager.StartListening();
                    //*write the code where it waits a little bit then 
                    _spmanager.Close();
     }
