    public void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        m_backgroundWorker.ReportProgress(0, "Extracting MX codes {0}%");
        using (var reader = new StreamReader(m_sThreadSettings.strFile))
        {
            Stream baseStream = reader.BaseStream;
            long length = baseStream.Length;
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Length > 8 && line.Substring(0, 4) == "080,")
                {
                    string strCode = line.Substring(4, 4);
                    if (m_sThreadSettings.lbCodes.FindStringExact(strCode) == -1)
                        m_sThreadSettings.pMainForm.Invoke(new MethodInvoker(delegate { m_sThreadSettings.lbCodes.Items.Add(strCode); }));
                    else
                        m_sThreadSettings.pMainForm.Invoke(new MethodInvoker(delegate { m_sThreadSettings.lbCodesDuplicate.Items.Add(strCode); }));
                }
                m_backgroundWorker.ReportProgress(Convert.ToInt32((100 / (double)length) * baseStream.Position), "Extracting MX codes {0}%");
            }
        }
    }
