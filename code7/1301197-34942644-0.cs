    DataSet ds = new DataSet();
    DataTable dt = new DataTable("Registration Details");
    DataTable dt1 = new DataTable("Education Details");
    DataTable dt2 = new DataTable("Employeement Details");
    dt = bl.Get_Registrationdetailsbydate(bo);
    gv_Regdetails.DataSource = dt;
    gv_Regdetails.DataBind();
    dt1 = bl.Get_Registrationdetailsbydate1(bo);
    dt2 = bl.Get_Registrationdetailsbydate2(bo);
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
