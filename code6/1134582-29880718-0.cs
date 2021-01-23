        // create an instance of the formMain
        formMain _formMain = new formMain();
        public void btnDynaDotCheck_Click(object sender, EventArgs e)
        {
            if (_formMain.bgWorker.IsBusy != true)
            {
                this.btnDynaDotCheck.Enabled = false;
                _formMain.bgWorker.RunWorkerAsync("dr_begin_dd_check");
            }
            else
            {
                _formMain.returnMessage("Please wait untill the current task is finished...");
                return;
            }
        }
