    Mapper.CreateMap<double?, double>().ConvertUsing<NullableDoubleConverter>();
    private class NullableDoubleConverter : TypeConverter<double?, double>
    {
        protected override double ConvertCore(double? source)
        {
            if (source == null)
                return Constants.NullDouble;
            else
                return (double)source;
        }
    }
