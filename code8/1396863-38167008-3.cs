    public abstract class LeaseTests<T>
    {
        public static IEnumerable<object[]> SampleValues()
        {
            var targetType = typeof (ISampleDataProvider<>).MakeGenericType(typeof (T));
            var sampleDataProviderType = Assembly.GetAssembly(typeof (ISampleDataProvider<>))
                                                    .GetTypes()
                                                    .FirstOrDefault(t => t.IsClass && targetType.IsAssignableFrom(t));
            if (sampleDataProviderType == null)
            {
                throw new NotSupportedException();
            }
            var sampleDataProvider = (ISampleDataProvider<T>)Activator.CreateInstance(sampleDataProviderType);
            return sampleDataProvider.CreateSampleValues().Select(value => new object[] {value});
        }
    ...
