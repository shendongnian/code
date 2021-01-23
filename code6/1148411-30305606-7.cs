            public override void OnStop()
        {
            Debug.WriteLine("OnStop_Begin");
            tokenSource.Cancel();
            tokenSource.Token.WaitHandle.WaitOne();
            base.OnStop();
            Debug.WriteLine("Onstop_End");
            tokenSource.Dispose();
        }
