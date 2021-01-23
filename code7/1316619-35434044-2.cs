    public static async void Main()
    {
        await DoSomething();
        await DoSomethingAsync();
    }
    
    private static Task DoSomethingTwice()
    {
        var do1 = MyLibrary.DoSomethingAsync();
    
        // when you await DoSomethingTwice, next line's reached
        // when do1 task may not be completed
        var do2 = MyLibrary.DoSomethingAsync();
        
        // return what???
        // how to combine them?
    
        // okay, you can do that
        return Task.WhenAll(do1, do2)
    }
    
    private static async Task DoSomethingTwiceAsync()
    {
        await MyLibrary.DoSomethingAsync().ConfigureAwait(false);
    
        // when you await DoSomethingTwiceAsync, next line's reached 
        // when prev-line task is completed
        await MyLibrary.DoSomethingAsync().ConfigureAwait(false);
    }
    
    public class MyLibrary
    {
        public static async Task DoSomethingAsync()
        {
            // Here is some I/O
        }
    }
