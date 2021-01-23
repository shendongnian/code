    private int SlowCalculation(int a, int b)
    {
        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));
        return a + b;
    }
    private async Task<int> CalculateAsync(int a, int b)
    {
        Task<int> myTask = Task.Run( () => SlowCalculation(a, b);
        // while SlowCalcuation is calculating slowly, do other useful things
        // after a while you need the answer
        int sum = await myTask;
        return sum;
    }
