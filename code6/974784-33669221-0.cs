     FormClosing += Launcher_FormClosing;
    
    
         private void Launcher_FormClosing(object sender, FormClosingEventArgs e)
         {
                FinallizeInstances();
         }
    
            public void FinallizeInstances()
            {
    
                foreach (var docked in _processCollection) {
                    docked.Value.Close();
                }
                _processCollection.Clear();
            }
    
    
            private void Launcher_FormClosing(object sender, FormClosingEventArgs e)
            {
                FinallizeInstances();
            }
    
    
            protected override void Dispose(bool disposing)
            {
                FinallizeInstances();
    
                if (disposing && (components != null)) {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
