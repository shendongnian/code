            while (sending)
        {
                    Thread EventSenderThread = new Thread(() =>
                        Communications.EventSender(Event_Directory));
                    EventSenderThread.Start();
                    while (EventSenderThread.IsAlive)
                    { System.Windows.Forms.Application.DoEvents(); }
        }
