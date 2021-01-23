    MimeKit.MimeMessage newmsg = null;
    if (!downloaded.Contains(uids[i]))
    {
        ...
        newmsg = client.GetMessage(i);
    }
    backgroundWorker1.ReportProgress(nProgress, newmsg );
