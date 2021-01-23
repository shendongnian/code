    class ConfigurationFactory
    {
        public static TConfig FromFile<TConfig>() where TConfig : BaseConfiguration
        {
            //you should have a TConfig-fileName mapping
            //e.g. a Dictionary<Type, string>
            //Type is typeof(TConfig) and string is the filename
        }
        public static TConfig FromDataBase<TConfig>() where TConfig : BaseConfiguration
        {
            //as I said, the original design has a lot of restricts
            //what if they change the storage from file to data base?
            //you need to change every derived class, renaming FileName to DataBaseTableName?
        }
    }
