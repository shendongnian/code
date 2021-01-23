    private sealed class MyCsvConverterMap : CsvClassMap<MyDestinationType>
    {
        public MyCsvConverterMap()
        {
            Map(item => item.YourProperty).Name("MyColumn");
            // map all properties in your destination to a column
        }
    }
    using (TextReader txtReader = new StringReader(...))
    {
        CsvReader csvReader = new CsvReader(txtReader);
        csvReader.Configuration.Delimiter = ";";
        csvReader.Configuration.HasHeaderRecord = true;
        csvReader.Configuration.RegisterClassMap(new MyCsvConverterMap());
        while (csvReader.Read())
        {
             MyDestinationType convertedRecord = csvReader.GetRecord<MyDestinationType>();
             ...
 
