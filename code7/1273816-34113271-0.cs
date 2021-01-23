            UnixSignal [] signals = new UnixSignal[] { 
                new UnixSignal(Signum.SIGINT), 
                new UnixSignal(Signum.SIGTERM), 
            };
            // Wait for a unix signal
            for (bool exit = false; !exit; )
            {
                int id = UnixSignal.WaitAny(signals);
                if (id >= 0 && id < signals.Length)
                {
                    if (signals[id].IsSet) exit = true;
                }
            }
