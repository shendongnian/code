    public void RunEngine()
        {
            if (worker.CancellationPending)
            {
                view.timer.Enabled = false;
                view.timer.Stop();
                // here I should be able to set e.Cancel = true;
                //As we stored the value before start the worker, now we can cancel here
                DoWorkEventArgsIntance.Cancel = true;
                return;
            }
            double oxygenLevel = _systemEngine.Subsystems.First(s => s.Article == "Oxygen").State.Level;
            if (oxygenLevel > 0)
            {
                ConsumeEngine();
            }
            else
            {
                worker.CancelAsync();
            }
        }
