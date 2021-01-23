        void m_oWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("Loading Cancelled.");
            }
            else if (e.Error != null)
            {
                MessageBox.Show("Error while performing background operation.");
            }
            else
            {
                if (lst2.Count < totalData)
                {
                    bs.ResetBindings(false);
                    m_oWorker.RunWorkerAsync();
                }
                else
                {
                    bs.ResetBindings(false);
                }
            }
        }
