    if ((args.Length == 0 || args[0] == "s"))
            {
                try
                {
                    RegisterServer();
                }
                catch (RemotingException)
                {
                    // try to register it with the pipe name. If it fails, means server is already running.
                    //bad idea, I know, but it's just for barebone quick test
                    RegisterClient();
                    isClient = true; // this is the line you need to add
                    remoteObject.OnNewProcessStarted("test");
                    Application.Exit();
                    return;
                }
