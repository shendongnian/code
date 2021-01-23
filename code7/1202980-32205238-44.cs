    namespace VBEAddin
    {
        [ComVisible(true), Guid("3599862B-FF92-42DF-BB55-DBD37CC13565"), ProgId("VBEAddIn.Connect")]
        public class Connect : IDTExtensibility2
        {
            private VBE _VBE;
            private AddIn _AddIn;
    
            #region "IDTExtensibility2 Members"
    
            public void OnConnection(object application, ext_ConnectMode connectMode, object addInInst, ref Array custom)
            {
                try
                {
                    _VBE = (VBE)application;
                    _AddIn = (AddIn)addInInst;
    
                    switch (connectMode)
                    {
                        case Extensibility.ext_ConnectMode.ext_cm_Startup:
                            break;
                        case Extensibility.ext_ConnectMode.ext_cm_AfterStartup:
                            InitializeAddIn();
    
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
    
            private void onReferenceItemAdded(Reference reference)
            {
                //TODO: Map types found in assembly using reference.
            }
    
            private void onReferenceItemRemoved(Reference reference)
            {
                //TODO: Remove types found in assembly using reference.
            }
    
            public void OnDisconnection(ext_DisconnectMode disconnectMode, ref Array custom)
            {
            }
    
            public void OnAddInsUpdate(ref Array custom)
            {
            }
    
            public void OnStartupComplete(ref Array custom)
            {
                InitializeAddIn();
            }
    
            private void InitializeAddIn()
            {
                MessageBox.Show(_AddIn.ProgId + " loaded in VBA editor version " + _VBE.Version);
                Form1 frm = new Form1();
                frm.Show();   //<-- HERE I AM INSTANTIATING A FORM WHEN THE ADDIN LOADS FROM THE VBE IDE!
            }
    
            public void OnBeginShutdown(ref Array custom)
            {
            }
    
            #endregion
        }
    }
