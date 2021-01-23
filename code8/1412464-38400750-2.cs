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
        //using lookup Enum
        public static bool Exists(ClassTypeEnum type, int id)
        {
            return Exists(id,Lookup.GetPossibles(type));
        }
        public static string ValidateExists(ClassTypeEnum type,int id)
        {
            return Exists(type,id) ? String.Empty : Lookup.GetError(type);
        }
    }
    public static class Lookup<T>
          where T:IExists
    [
         public IEnumerable<T> GetPossibles(ClassTypeEnum type)
         {
             switch(type)
             {
                 case ClassTypeEnum.City:
                     return //source of Cities;
             }
         }
         public IEnumerable<T> GetError(ClassTypeEnum type)
         {
             switch(type)
             {
                 case ClassTypeEnum.City:
                     return ConfigTranslationCode.CityNotExist;
             }
         }
