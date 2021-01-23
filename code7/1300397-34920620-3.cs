    dt = bl.Get_Registrationdetailsbydate1(bo);
    dt1 = bl.Get_Registrationdetailsbydate2(bo);
    DataTable filteredEducation = dt1.AsEnumerable()
                                     .Where(x => dt.AsEnumerable()
                               .Any(z => z.Field<string>("Email") == x.Field<string>("Email")))
                               .CopyToDataTable();
    ds.Tables.Add(dt);
    ds.Tables.Add(filteredEducation);
    ExcelHelper.ToExcel(ds, "DangoteUsers.xls", Page.Response);   
