    private HashSet<string> downloaded = new HashSet<string> ();
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        using (var client = new Pop3Client())
        {
            client.Connect(textServer.Text, Convert.ToInt32(textPort.Text), ssl);
            client.AuthenticationMechanisms.Remove("XOAUTH2");
            client.Authenticate(textUser.Text, textPassword.Text);
            var uids = client.GetMessageUids ();
            for (int i = 0; i < client.Count; i++)
            {
                if (backgroundWorker1.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                if (!downloaded.Contains (uids[i]))
                {
                    allMessages.Add(client.GetMessage(i));
                    downloaded.Add (uids[i]);
                }
                int nProgress = (client.Count - i + 1) * 100 / client.Count;
                backgroundWorker1.ReportProgress(nProgress, client.Count.ToString() + "/" + i);
            }
            client.Disconnect(true);
        }
