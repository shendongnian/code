    class Sample1
    {
        public void SampleMethod1()
        {
           TryExecute(() => /* code for method */);             
        }
    
        public void SampleMethod2()
        {
           TryExecute(() => /* code for method */);             
        }
    
        private void TryExecute(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
