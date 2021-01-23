    public static string OpretBrugerPointAdd()
    {
        using(var db = new DataClassesDataContext())
        {
            PointBonus pointbonusStart = db.PointBonus.FirstOrDefault(P => P.Id == 1);
            if (pointbonusStart != null)
            {
                return Convert.ToString(pointbonusStart.point);
            }
        }
    }
