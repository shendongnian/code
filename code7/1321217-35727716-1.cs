    [HandleException(typeof(ExceptionOfTypeA))]
        public HttpResponseMessage Get(int id)
        {
            throw new ExceptionOfTypeA();
        }
