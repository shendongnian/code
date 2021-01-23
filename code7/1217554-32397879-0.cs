        class Beeper
        {
            private int _gapMiliseconds;
            private bool _stop = false;
            public Beeper(int gapMiliseconds)
            {
                _gapMiliseconds = gapMiliseconds;
            }
            public void Start()
            {
                while (!_stop)
                {
                    Console.Beep();
                    Thread.Sleep(_gapMiliseconds);
                }
            }
            public void Stop()
            {
                _stop = true;
            }
        }
