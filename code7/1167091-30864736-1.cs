    while (!stopSending)
    {
        if (QueueMailingHandler.m_numActive >= MaxThreads)
        {
            Thread.Sleep(2000);
            continue;
        }
        QMail mailRecord = QMail.Next();
        if (mailRecord.UID > 0)
        {
            QueueMailingHandler.m_numActive++;
            QueueMailingHandler MailingHandler = new QueueMailingHandler();
            mailRecord.Processing = true;
            MailingHandler.Start(mailRecord);
        }
        Thread.Sleep(200);
    }
