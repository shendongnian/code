        private  void Button_Click(object sender, RoutedEventArgs e)
        {
            var ac = new Action(() => Application.Current.Dispatcher.Invoke(
                () =>
                {
                    Thread.Sleep(50);
                }));
            Task.Factory.StartNew(() =>
            {
                //Provide path to epi
                string epiPath = @"c:/EPISUITE41";
                Level3ntCalculator cl = new Level3ntCalculator();
                var runner = new Calculators.Epi.Runners.ProcessRunner(epiPath, ac);
                runner.WriteXSmilesFiles("CCCCC1CCCCCCC1");
                        cl.Calculate(runner);
            });
        }
