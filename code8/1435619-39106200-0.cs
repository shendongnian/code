    namespace MyLibrary1
    {
        public class ClassFromMyLibrary1
        {
            public async Task<string> MethodFromMyLibrary1(string key)
            {
                var remoteValue = await GetValueByKey(key).ConfigureAwait(false);
                return remoteValue;
            }
    
            public string TransformProcessedValue(string processedValue)
            {
                return string.Format("Processed-{0}", processedValue);
            }
    
            private async Task<string> GetValueByKey(string key)
            {
                //simulate time-consuming operation
                await Task.Delay(500).ConfigureAwait(false);
    
                return string.Format("ValueFromRemoteLocationBy{0}", key);
            }
        }
    }
