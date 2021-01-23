    var baseDate = new DateTime(2001, 4, 10); // 10-apr-2001
    var minDate = new DateTime(2001, 4, 1);   // 1-apr-2001
    var maxDate = new DateTime(2099, 1, 1);   // 1-jan-2099
    data = (from e in db.EMPLOYEE
            where workStatus.Contains(e.WORKSTAT)
                && company.Contains(e.CO.Substring(0, 2))
                && ((e.EVENT_TYP != "35") || (e.EVENT_TYP == "35" && !eventReason.Contains(e.EVENT_RSN)))
            orderby e.CO_SENIORITY == null ? maxDate :
                e.PREV_CO == "ABC" && e.CO_SENIORITY < baseDate ? minDate :
                e.CO_SENIORITY,
                e.BIRTH_DT
            select new Employee
            {
                Co = e.CO,
                CityCode = e.CITY_CODE,
                EmployeeNumber = e.EMP,
                LastName = e.LAST_NAME,
                FirstName = e.FIRST_NAME,
                Position = e.ABV_POSITION_TITLE,
                EmploymentType = e.PART_TIME_IND == "X" ? "PT" : "FT",
                SeniorityDate = e.CO_SENIORITY,
                BirthDate = e.BIRTH_DT,
                PreviousCo = e.PREV_CO
            }).ToList();
