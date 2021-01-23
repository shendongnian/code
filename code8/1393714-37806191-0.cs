    using System.Globalization;
    public static string convertDate(string dt)
    {
        string cdate = "";
        try
        {
            IFormatProvider culture = new CultureInfo("en-US", true);   
            DateTime dts = DateTime.ParseExact(dt, "dd/MM/yyyy", culture);
            cdate = dts.ToString("yyyyMMdd");
        }
        catch (Exception ex)
        {
        }
        return cdate;
    }
