        private void backgroundWorker_RunWorkerComplet(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else
            {
                MessageBox.Show(e.Result.ToString());
                GuiForm_Load(sender, e);
            }
        }
