            public override void Execute(XObjectList itemList, ProcessInfo processInfo) {
            execute(itemList, processInfo);
            ManualResetEvent syncEvent = new ManualResetEvent(false);
            //openScreen();
            Thread STAThread = new Thread(() => {
                var window = new Window();
                window.Content = new MailViewerView();
                window.ShowDialog();
                syncEvent.Set();
            });
            STAThread.SetApartmentState(ApartmentState.STA);
            STAThread.Start();
            syncEvent.WaitOne();
        }
