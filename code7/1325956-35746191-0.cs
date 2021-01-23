        SmaccLib smacclib = new SmaccLib();
        smaccDate = smacclib.Date_SaveFormat(date);
        List<EmployeeAbsents> listEmployeeAbsents = _hrManager.EmployeeAbsentManager.SelectEmployeeAbsentsByDate(smaccDate, rowIndex);
        if (listEmployeeAbsents != null && listEmployeeAbsents.Count > 0)
        {
            return JsonConvert.SerializeObject(listEmployeeAbsents);
        }
        return string.Empty;
