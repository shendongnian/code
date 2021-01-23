    public class TickTradeClassMap : CsvHelper.Configuration.CsvClassMap<TickData.TickTrade>
		{
			public TickTradeClassMap()
			{
				Map(m => m.price);
				Map(m => m.size);
				Map(m => m.exchange).TypeConverter<OurEnumConverter<ATExchangeEnum>>();
				Map(m => m.condition1).TypeConverter<OurEnumConverter<ATTradeConditionEnum>>();
			}
		}
