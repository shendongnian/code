        void m_oWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Load data
            using (QLQT db = new QLQT())
            {
                lst2.AddRange(db.tblDuToanPhanBos.Skip(RowsTaken).Take(RowsToTake).ToList());
            }
            // Update number of rows loaded
            RowsTaken = lst2.Count;
            if (((BackgroundWorker)sender).CancellationPending)
            {
                e.Cancel = true;
                return;
            }
        }
