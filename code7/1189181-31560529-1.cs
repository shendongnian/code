        private void UserControl1_Load(object sender, EventArgs e)
        {
            m_oWorker = new BackgroundWorker();
            m_oWorker.DoWork += new DoWorkEventHandler(m_oWorker_DoWork);
            m_oWorker.ProgressChanged += new ProgressChangedEventHandler (m_oWorker_ProgressChanged);
            m_oWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler (m_oWorker_RunWorkerCompleted);
            // QLQT is my DataContext
            using (QLQT db = new QLQT())
            {
                lst2.AddRange(db.tblDuToanPhanBos.Skip(RowsTaken).Take(RowsToTake).ToList());
            }
            RowsTaken = lst2.Count;
            bs.DataSource = lst2;
            dataGridView1.DataSource = bs;
            m_oWorker.RunWorkerAsync();
        }
