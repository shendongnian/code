    List<Employee> listObject = dTable.AsEnumerable()
                                      .Select(x => new Employee()
                                      {
                                        EmpId = x.Field<int>("EmpId"),
                                        EmpName = x.Field<string>("EmpName"),
                                        EmpAddress = x.Field<string>("EmpName"),
                                        EmpPhone = x.Field<string>("EmpPhone"),
                                        Status = x.Field<bool>("Status"),
                                        EmpRelationKey = x.Field<int>("EmpRelationKey")
                                      }).ToList();
