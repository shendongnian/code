            public static bool TryChangeType<T, TR>(T input, out TR output) where T : IConvertible
        {
            bool result = false;
            try
            {
                Type type = Nullable.GetUnderlyingType(typeof(TR));
                output = (TR)Convert.ChangeType(input, type);
                result = true;
            }
            catch(Exception)
            {
                output = default(TR);
            }
            return result;
        }
