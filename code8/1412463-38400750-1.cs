    public static class ValidatorNotExistHelper<T>
          where T:IExists
    {
        public static bool Exists(int id,IEnumerable<T> possibles)
        {
            return possibles.Any(p=>p.id == id);
        }
        public static string ValidateExists(int id,IEnumerable<T> possibles,string ErrorMessage)
        {
            return Exists(id,possibles) ? String.Empty : ErrorMessage;
        }
    }
