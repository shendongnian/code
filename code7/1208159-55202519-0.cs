        public static async Task<ResultType> Transform(SourceType original)
        {
            // some async work 
            var transformed = await DoSomething(original)
            return transformed;
        }
Provide these generic extension methods (pretty much the same as @Gennadii Saltyshchak's PipeSync methods, but I find the "Then" moniker much more succinct):
        public static async Task<T2> Then<T1, T2>(this T1 first, Func<T1, Task<T2>> second)
        {
            return await second(first).ConfigureAwait(false);
        }
        public static async Task<T2> Then<T1, T2>(this Task<T1> first, Func<T1, Task<T2>> second)
        {
            return await second(await first.ConfigureAwait(false)).ConfigureAwait(false);
        }
        public static async Task<T2> Then<T1, T2>(this Task<T1> first, Func<T1, T2> second)
        {
            return second(await first.ConfigureAwait(false));
        }
        public static Task<T2> Then<T1, T2>(this T1 first, Func<T1, T2> second)
        {
            return Task.FromResult(second(first));
        }
You can then construct a fluent chain like this:
        var processed = await Transform1(source)
            .Then(Transform1)
            .Then(Transform2)
            .Then(Transform3);
Thanks to the Then() overloads, this works with any permutation of async/sync methods.
If e.g. Transform2 takes arguments, you need to expand to a lambda:
        var processed = await Transform1(source)
            .Then(Transform1)
            .Then(x => Transform2(x, arg1, arg2))
            .Then(Transform3);
I think this is as close to a fluent async chain as you can get with the current language!
Combinations of async/sync should be optimized with ValueTask<T> where possible.  An exercise for the reader!  :-)
