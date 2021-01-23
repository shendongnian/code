      void heartBeatTimer_Tick(object sender, EventArgs e)
        {
            var result = cycle.Execute(new Resource(0)); // starting the cycle with initial value of 0
            Console.WriteLine("Cycle completed result {0}", result.Value); 
        }
