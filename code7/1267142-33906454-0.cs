    String dateBegin = 
        FillRateRptConstsAndUtils.GetYYYYDashMMDashDD(_dateBegin, true);
    String dateEnd =
        FillRateRptConstsAndUtils.GetYYYYDashMMDashDD(_dateEnd, false);
    DataTable dtFillRateResults =
        SqlDBHelper.ExecuteSQLReturnDataTable("sp_CRP_FillRate2",
            CommandType.StoredProcedure,
            new SqlParameter() { ParameterName = "@Unit", SqlDbType
    = SqlDbType.VarChar, Value = _unit },
            new SqlParameter() { ParameterName = "@Member",
    SqlDbType = SqlDbType.VarChar, Value = _member },
            new SqlParameter() { ParameterName = "@BegDate",
    SqlDbType = SqlDbType.DateTime, Value = Convert.ToDateTime(dateBegin) },
            new SqlParameter() { ParameterName = "@EndDate",
    SqlDbType = SqlDbType.DateTime, Value = Convert.ToDateTime(dateEnd) }
        );
    public static string GetYYYYDashMMDashDD(DateTime rawDate, bool startOfRange)
    {
        int year = rawDate.Year;
        int month = rawDate.Month;
        String monthAsStr = month.ToString();
        if (monthAsStr.Length == 1)
        {
            monthAsStr = "0" + monthAsStr;
        }
        var dayVal = startOfRange ? "01" : GetLastDayOfMonth(month, year.ToString());
        if (dayVal.Length == 1)
        {
            dayVal = "0" + dayVal;
        }
        return String.Format("{0}-{1}-{2}", year, monthAsStr, dayVal);
    }
