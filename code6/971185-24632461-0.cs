        void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if ((backgroundWorker2.CancellationPending == true))
                {
                    e.Cancel = true;
                }
                if (!this.IsDisposed || this.Disposing)
                {
                    if (tb_recsuffix.Text.Length > 0 && tb_filename.Text.Length > 0)
                        SetControlPropertyThreadSafe(btn_ok, "Enabled", true);
                    else SetControlPropertyThreadSafe(btn_ok, "Enabled", false);
                }
                Thread.Sleep(500);
            }
        }
