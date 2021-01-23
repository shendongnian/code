    private void lstCheckedListBox_DoubleClick(object sender, EventArgs e)
        {
            if (bckWorkerPt.IsBusy)
            {
                sender = null;
                e = null;
            }
        }
