    private class UnspeakableName<X>
    {
        public IConverter<X> converter;
        public object Method(object obj)
        {
            return converter(obj);
        }
    }
