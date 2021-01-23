        private void LockKeys()
        {
            //Set them all default false, and then only enable.
            btnSR.Enabled = false;
            btnVSC.Enabled = false;
            btnPT.Enabled = false;
            btnCT.Enabled = false;
            btnTS.Enabled = false;
            btnBookJob.Enabled = false;
            btnCompJob.Enabled = false;
            btnCompServ.Enabled = false;
            btnVS.Enabled = false;
            if(AccessLevel == 1)
            {
                btnVS.Enabled = true;
            }
            else if (AccessLevel == 2)
            {
                btnBookJob.Enabled = true;
                btnCompJob.Enabled = true;
            }
            else if (AccessLevel == 3)
            {
                btnBookJob.Enabled = true;
                btnCompServ.Enabled = true;
            }
            else if (AccessLevel == 4)
            {
                btnTS.Enabled = true;
            }
        }
