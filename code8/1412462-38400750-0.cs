    public static class ValidatorNotExistHelper
    {
        public static bool Exists<T>(int id,IEnumerable<T> possibles)
          where T:IExists
        {
            return possibles.Any(p=>p.id == id);
        }
        public static bool ValidateExists<T>(int id,IEnumerable<T> possibles,string ErrorMessage)
          where T:IExists
        {
            return Exists(id,possibles) ? String.Empty : ErrorMessage;
        }
    }
