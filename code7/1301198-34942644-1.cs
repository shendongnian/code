    DataSet ds = new DataSet();
    var dt = bl.Get_Registrationdetailsbydate(bo);
    gv_Regdetails.DataSource = dt;
    gv_Regdetails.DataBind();
    var dt1 = bl.Get_Registrationdetailsbydate1(bo);
    var dt2 = bl.Get_Registrationdetailsbydate2(bo);
    DataTable filteredEducation = dt1.AsEnumerable()
                                     .Where(x => dt.AsEnumerable()
                               .Any(z => z.Field<string>("Email").Trim() == x.Field<string>("Email").Trim()))
                               .CopyToDataTable();
    DataTable filteredEmployee = dt2.AsEnumerable()
                                    .Where(x => dt.AsEnumerable()
                              .Any(z => z.Field<string>("Email").Trim() == x.Field<string>("Email").Trim()))
                              .CopyToDataTable();
    dt.TableName = "Registration Details";
    filteredEducation.TableName = "Education Details";
    filteredEmployee.TableName = "Employeement Details";
    ds.Tables.Add(dt);
    ds.Tables.Add(filteredEducation);
    ds.Tables.Add(filteredEmployee);
    ExcelHelper.ToExcel(ds, "DangoteUsers.xls", Page.Response);
