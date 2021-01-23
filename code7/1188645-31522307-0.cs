    private void ChangeDate(int numDays)
    {
        Systemtime st = new Systemtime();
        var newDate = DateTime.Now.AddDays(numDays);
        
        //Set up all the values, no need to set wDayOfWeek as it's ignored by the set function
        st.wYear = newDate.Year;
        st.wMonth = newDate.Month;
        st.wDay = newDate.Day;
        st.wHour = newDate.Hour;
        st.wMinute = newDate.Minute;
        st.wSecond = newDate.Second;
        st.wMilliseconds = newDate.Millisecond;
   
        SetSystemTime(ref st);
    }
