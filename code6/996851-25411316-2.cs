        public static T GetLogic<TDal, T>(TDal item)
        {
            return default(T);
        }
        class StaticConverter<TDal, T>
            where T : LogicClass<TDal>
        {
            public static Converter<TDal, T> Converter = c => GetLogic<TDal, T>(c);
        }
