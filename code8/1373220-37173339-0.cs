      private IList<T> GetGenericList<T>()
      {
         Type parmType = typeof(T);
         if (!parmType.Equals(typeof(double)) && !parmType.Equals(typeof(long)))
         {
            return null;
         }
         else
         {
            IList<T> Result = new List<T>();
            if (parmType.Equals(typeof(double)))
            {
               T Value = (T)(object)2.5;
               Result.Add(Value);
            }
            else
            {
               T Value = (T)(object)2L;
               Result.Add(Value);
            }
            return Result;
         }
      }
