    Device.StartTimer(System.TimeSpan.FromMilliseconds(200), () =>
            {
                myProgressBar.Progress += 0.01;
                if (myProgressBar.Progress > .5)
                {
                    myProgressBar.Progress = 0;
                    return false;
                }
                return true;
            });
