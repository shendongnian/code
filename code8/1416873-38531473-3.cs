        public static void SomeAlgorithm(int? parameterOne, int? parameterTwo)
        {
            var values = new { FirstParameter = parameterOne, SecondParameter = parameterTwo };
            foreach(PropertyInfo info in values.GetType().GetProperties())
            {
                if(info.GetValue(values) == null)
                {
                    //Your code would go here.
                }
            }
        }
