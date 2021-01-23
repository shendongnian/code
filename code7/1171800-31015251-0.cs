    public static DateTime DatoFrom()
    {
        DataClassesDataContext db = new DataClassesDataContext();
    
        var RabatPriser = db.RabatPrisers.FirstOrDefault(A => A.Id == 1);
        if (RabatPriser != null)
        {
            return RabatPriser.fromdato;
        }
        //Instead of 0, return the minimum value?
        return DateTime.MinValue;
    }
