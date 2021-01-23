    // destination object
    public class FxConversionRate
    {
        public DateTime Date { get; set; }
        public string Currency { get; set; }
        public double Rate { get; set; }
    }
    // file format specification (FileHelpers class)
    [DelimitedRecord(","), IgnoreFirst(1)]
    public class FxConversionRateSpec
    {
        [FieldConverter(ConverterKind.Date, "d/M/yyyy")]
        public DateTime Date;
        public double[] Rates;
    }
    class Program
    {
        static void Main(string[] args)
        {
            // trimmed down contents...
            var contents =
            @"DATE,AUD,CAD,CHF" + Environment.NewLine +
            @"1/1/2000,88,71,3" + Environment.NewLine +
            @"2/1/2000,82,83,86";
            // get the records
            var engine = new FileHelperEngine<FxConversionRateSpec>();
            var records = engine.ReadString(contents);
            // get the header
            var currencies = contents
                .Substring(0, contents.IndexOf(Environment.NewLine)) // take the first line
                .Split(',') // split into currencies
                .Skip(1); // skip the 'Date' column
            // as IEnumerable<FxConversionRate>
            var rates = records.SelectMany( // for each record of Date, Double[]
                record => currencies.Zip(record.Rates, (c, r) => new { Currency = c, Rate = r}) // combine the rates array with the currency labels
                    .Select( // for each of the anonymous typed records Currency, Double
                        currencyRate => 
                                new FxConversionRate
                                    {
                                        Date = record.Date,
                                        Currency = currencyRate.Currency,
                                        Rate = currencyRate.Rate
                                }));
            Assert.AreEqual(6, rates.Count(), "Exactly 6 records were expected");
            Assert.That(rates.Single(x => x.Date == new DateTime(2000, 1, 1) && x.Currency == "AUD" && x.Rate == 88d) != null);
            Assert.That(rates.Single(x => x.Date == new DateTime(2000, 1, 1) && x.Currency == "CAD" && x.Rate == 71d) != null);
            Assert.That(rates.Single(x => x.Date == new DateTime(2000, 1, 1) && x.Currency == "CHF" && x.Rate == 3d) != null);
            Assert.That(rates.Single(x => x.Date == new DateTime(2000, 1, 2) && x.Currency == "AUD" && x.Rate == 82d) != null);
            Assert.That(rates.Single(x => x.Date == new DateTime(2000, 1, 2) && x.Currency == "CAD" && x.Rate == 83d) != null);
            Assert.That(rates.Single(x => x.Date == new DateTime(2000, 1, 2) && x.Currency == "CHF" && x.Rate == 86d) != null);
            Console.WriteLine("All tests passed OK.");
            Console.ReadKey();
        }
    }
