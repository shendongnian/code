    internal static DateTime? GetDateOfLastSkew(DateTime date, DateTime expiry)
    {
      using (SAFEX db = new SAFEX())
      {
        return (from skew in db.Skew
             where skew.CalibrationDate.Date <= date.Date
                && skew.Expiry.Date == expiry.Date
             select skew.CalibrationDate).Max(); // Max returns a DateTime.
      }
    }
