    public static class TokenBucketExtensions
    {
        public static Task ConsumeAsync(this ITokenBucket tokenBucket)
        {
            return Task.Factory.StartNew(tokenBucket.Consume);
        }
    }
