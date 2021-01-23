	// note that I added cancellation support, this is personal preference
    public interface IFoo
    {
        Task<String> FooBarAsync(CancellationToken token);
    }
    public class Foo : IFoo
    {
        public async Task<String> FooBarAsync(CancellationToken token)
        {
            await Task.Delay(500, token);
            return "";
        }
    }
    public static class FooSyncExtender
    {
        public static String FooBar(this IFoo foo)
        {
            // this is one way to call async from sync code
            return foo.FooBarAsync(CancellationToken.None).GetAwaiter().GetResult();
        }
    }
