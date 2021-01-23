    private void StartAlgo()
        {
            while (Algo.CurrentAge <= Algo.MaxNumberOfAges)
            {
                Matrix = Algo.LearnAge(GeneratedPoints);
                this.Dispatcher.Invoke(new Action(() =>
                {
                    View.Children.Clear();
                    DrawPoints();
                    DrawMatrix();
                }));
                
            }
        }
        
