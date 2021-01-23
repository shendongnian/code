    class DataReaderMapper<YourClass>
    {
        static DataReaderMapper()
        {
            Mapper.Initialize(cfg =>
            {
                MapperRegistry.Mappers.Add(new AutoMapper.Data.DataReaderMapper { YieldReturnEnabled = true });
            });
            Mapper.CreateMap<IDataReader, YourClass>();
        }
        public static IEnumerable<YourClass> GetRecordes(IDataReader reader)
        {
            return  Mapper.Map<IDataReader, IEnumerable<YourClass>>(reader);
        }
    }
