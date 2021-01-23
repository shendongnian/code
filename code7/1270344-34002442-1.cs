    internal static DateTime? GetDateOfLastSkew(DateTime date, DateTime expiry)
    {
      using (SAFEX db = new SAFEX())
      {
        return (from skew in db.Skew
             where skew.CalibrationDate.Date <= date.Date
                && skew.Expiry.Date == expiry.Date
             select (DateTime?)skew.CalibrationDate).Max(); // Max returns a DateTime or null on no matches.
      }
    }
