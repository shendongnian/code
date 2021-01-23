    [TestFixture]
    public class CacheFixture
    {
        [Test]
        public async Task CachingTest()
        {
            var testScheduler = new TestScheduler();
            var cache = new InMemoryBlobCache(testScheduler);
            var cacheTimeout = TimeSpan.FromSeconds(10);
            var someApi = new Mock<ISomeApi>();
            someApi.Setup(s => s.GetSomeStrings())
                .Returns(Task.FromResult("helloworld")).Verifiable();
            
            var apiWrapper = new SomeApiWrapper(someApi.Object, cache, cacheTimeout);
            var string1 = await apiWrapper.GetSomeStrings();
            someApi.Verify(s => s.GetSomeStrings(), Times.Once());
            StringAssert.AreEqualIgnoringCase("helloworld", string1);
            testScheduler.AdvanceToMs(5000);
            
            var observer = testScheduler.CreateObserver<string>();
            apiWrapper.GetSomeStrings().Subscribe(observer);
            testScheduler.AdvanceByMs(cacheTimeout.TotalMilliseconds);
            someApi.Verify(s => s.GetSomeStrings(), Times.Once());
            StringAssert.AreEqualIgnoringCase("helloworld", observer.Messages[0].Value.Value);
        }
    }
    public interface ISomeApi
    {
        Task<string> GetSomeStrings();
    }
    public class SomeApiWrapper
    {
        private IBlobCache Cache;
        private ISomeApi Api;
        private TimeSpan Timeout;
        public SomeApiWrapper(ISomeApi api, IBlobCache cache, TimeSpan cacheTimeout)
        {
            Cache = cache;
            Api = api;
            Timeout = cacheTimeout;
        }
        public IObservable<string> GetSomeStrings()
        {
            var key = "somestrings";
            var cachedStrings = Cache.GetOrFetchObject(key, DoGetStrings,
                Cache.Scheduler.Now.Add(Timeout));
            //Return an observerable here instead of "blocking" with a task. -LC
            return cachedStrings.Take(1);
        }
        private async Task<string> DoGetStrings()
        {
            return await Api.GetSomeStrings();
        }
    }
