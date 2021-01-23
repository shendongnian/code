    var excel = new ExcelQueryFactory("excelFileName");
    excel.AddMapping<Company>(x => x.State, "Providence"); //maps the "State" property to the "Providence" column
    excel.AddMapping("Employees", "Employee Count");       //maps the "Employees" property to the "Employee Count" column
    
    var indianaCompanies = from c in excel.Worksheet<Company>()
                           where c.State == "IN" && c.Employees > 500
                           select c;
