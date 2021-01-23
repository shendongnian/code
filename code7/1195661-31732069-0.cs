        public static void TestGetter<T>(Func<T> method, T expectedVal)
        {       
            try
            {
                T actual = method();
                PassIfTrue(expectedVal.Equals(actual));
            }
            catch (Exception ex)
            {
                Fail(ex.Message);
            }
        }
        public static void TestSetter<T>(Action setMethod, Func<T> getMethod, T expectedVal)
        {
            try
            {
                setMethod();
                T actual = getMethod();
                PassIfTrue(expectedVal.Equals(actual));
            }
            catch (Exception ex)
            {
                Fail(ex.Message);
            }
        }
