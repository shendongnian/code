    Dim da As New SqlDataAdapter(cmd)
    da.TableMappings.Add("Table", "NRICType")
    da.TableMappings.Add("Table1", "Race")
    da.TableMappings.Add("Table2", "Nationality")
    da.TableMappings.Add("Table3", "Languages")
    da.TableMappings.Add("Table4", "Occupation")
    da.TableMappings.Add("Table5", "Country")
    
    da.Fill(ds)
