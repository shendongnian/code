    foreach (SPListItem item in collectionEmployeeDisplay)
                        {
                            DisplayEmployee dE = new DisplayEmployee();
                            dE.EmployeeName = item[Sol.PB1.Fields.EmployeeName].ToString();
                            dE.PhoneNumber = item[Sol.PB1.Fields.PhoneNumber].ToString();
                            dE.Position = item[Sol.PB1.Fields.Position].ToString();
                            display.Add(dE);
                        }
                        rptEmployees.DataSource = display;
                        rptEmployees.DataBind();
                    }
