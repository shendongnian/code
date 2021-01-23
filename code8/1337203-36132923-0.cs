    public abstract class DataSource
    {
        // base class for all data sources
        // maintains connections opening and closing plus 
        // thread safety concerns
        // these classes will most likely be private
        // maybe even within the universal data source class as inner classes
        // THE TWO METHODS BELOW ARE ONLY TO BE CALLED FROM WITHIN THE UniversalDataSource CLASS
        public abstract double GetRealTimeValue(Identifier id);
        public abstract double GetHistoricalValue(Identifier id, DateTime asof); 
    }
    public class FooDataSource : DataSource {
        public override double GetRealTimeValue(Identifier id)
        {
            return -1;
            // real implementation here, must be identifier type upcasting with runtime check
        }
        public override double GetHistoricalValue(Identifier id, DateTime asof)
        {
            return -2; 
            // real implementation here, must be identifier type upcasting with runtime check
        }
    }
    public class BarDataSource : DataSource {
        public override double GetRealTimeValue(Identifier id)
        {
            return -3; 
            // real implementation here, must be identifier type upcasting with runtime check
        }
        public override double GetHistoricalValue(Identifier id, DateTime asof)
        {
            return -4; 
            // real implementation here, must be identifier type upcasting with runtime check
        }
    }
    /// <summary>
    /// holds initialized references to all possible data sources
    /// </summary>
    public class UniversalDataSource 
    {
        public FooDataSource FooDS { get; internal set; }
        public BarDataSource BarDS { get; internal set; }
        public UniversalDataSource(FooDataSource fooDs, BarDataSource barDs)
        {
            this.FooDS = fooDs;
            this.BarDS = barDs;
        }
        public double GetRealTimeValue(Identifier id)
        {
            var specificDS = id.GetDataSource(this);
            return specificDS.GetRealTimeValue(id); 
        }
        public double GetHistoricalValue(Identifier id, DateTime asof)
        {
            var specificDS = id.GetDataSource(this);
            return specificDS.GetHistoricalValue(id, asof); 
        }
    }
    public abstract class Identifier
    {
        public string Value { get; internal set; }
        public Identifier(string value)
        {
            Value = value; 
        }
        /// <summary>
        /// returns the appropriate data source for THIS kind of identifier (abstractly)
        /// </summary>
        /// <param name="universalDataSource"></param>
        /// <returns></returns>
        public abstract DataSource GetDataSource(UniversalDataSource universalDataSource); 
    }
    public class FooIdentifier : Identifier
    {
        public FooIdentifier(string value) : base(value)
        {
            // checks go here on the string that comes in 
            // specific to the foo data source
        }
        public override DataSource GetDataSource(UniversalDataSource universalDataSource)
        {
            return universalDataSource.FooDS; 
        }
    }
    public class BarIdentifier : Identifier
    {
        public BarIdentifier(string value) : base(value)
        {
            // checks on the string values that come in for the Bar 
            // source 
        }
        public override DataSource GetDataSource(UniversalDataSource universalDataSource)
        {
            return universalDataSource.BarDS; 
        }
    }
    public abstract class DataContext
    {
        public UniversalDataSource DataSource { get; internal set; }
        protected DataContext(UniversalDataSource dataSource)
        {
            DataSource = dataSource;
        }
        public abstract double GetValue(Identifier id); 
    }
    public class RealTimeDataContext : DataContext {
        public RealTimeDataContext(UniversalDataSource dataSource) : base(dataSource)
        {
        }
        public override double GetValue(Identifier id)
        {
            return DataSource.GetRealTimeValue(id); 
        }
    }
    public class HistoricalDataContext : DataContext {
        public DateTime AsOf { get; internal set; }
        public HistoricalDataContext(UniversalDataSource dataSource, DateTime asof) : base(dataSource)
        {
            AsOf = asof; 
        }
        public override double GetValue(Identifier id)
        {
            return DataSource.GetHistoricalValue(id, AsOf); 
        }
    }
    [TestFixture]
    public static class TestMe
    {
        [Test]
        public static void MyTest()
        {
            // create the data context (to get data from) 
            var ds = new UniversalDataSource(
                new FooDataSource(),
                new BarDataSource()
                );
            var realTimeDataContext = new RealTimeDataContext(ds);
            var historicalDataContext = new HistoricalDataContext(ds, DateTime.MinValue);
            var fooId = new FooIdentifier("onetuhoenthuo");
            var barId = new BarIdentifier("onetuhoenthuo"); 
            // testing dispatch
            Assert.AreEqual(-1, realTimeDataContext.GetValue(fooId));
            Assert.AreEqual(-2, historicalDataContext.GetValue(fooId));
            Assert.AreEqual(-3, realTimeDataContext.GetValue(barId));
            Assert.AreEqual(-4, historicalDataContext.GetValue(barId)); 
        }
    }
