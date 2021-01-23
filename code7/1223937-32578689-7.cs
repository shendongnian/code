        private bool _systemShutdown;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WmQueryendSession)
            {
                _systemShutdown = true; // call here method to update status
            }
            base.WndProc(ref m);
        }
