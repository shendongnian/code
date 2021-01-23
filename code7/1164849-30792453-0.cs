            var xml = new XDocument(new XElement("Data",
                            new XElement("Parameter",
                                new XElement("ID", parameters[0].Id.ToString("B")), new XElement("Value", runbookId)), //RunbookID
                            new XElement("Parameter",
                                new XElement("ID", parameters[1].Id.ToString("B")), new XElement("Value", employee.JobTitle)), //Title
                            new XElement("Parameter",
                                new XElement("ID", parameters[2].Id.ToString("B")), new XElement("Value", employee.UserName)),//Username
                            new XElement("Parameter",
                                new XElement("ID", parameters[3].Id.ToString("B")), new XElement("Value", employee.LastName)), //Lastname
                            new XElement("Parameter",
                                new XElement("ID", parameters[4].Id.ToString("B")), new XElement("Value", GetManager(employee))), //Manager
                            new XElement("Parameter",
                                new XElement("ID", parameters[5].Id.ToString("B")), new XElement("Value", "")),  //Phone
                            new XElement("Parameter",
                                new XElement("ID", parameters[6].Id.ToString("B")), new XElement("Value", employee.Initials)),//GUI Initials
                            new XElement("Parameter",
                                new XElement("ID", parameters[7].Id.ToString("B")), new XElement("Value", employee.EmployeeNumber)), //Employee #
                            new XElement("Parameter",
                                new XElement("ID", parameters[8].Id.ToString("B")), new XElement("Value", GetCompany(employee))), //Company
                            new XElement("Parameter",
                                new XElement("ID", parameters[9].Id.ToString("B")), new XElement("Value", "")), //Employee Security
                            new XElement("Parameter",
                                new XElement("ID", parameters[10].Id.ToString("B")), new XElement("Value", GetDepartment(employee))), //Department
                            new XElement("Parameter",
                                new XElement("ID", parameters[11].Id.ToString("B")), new XElement("Value", employee.Location)), //Office
                            new XElement("Parameter",
                                new XElement("ID", parameters[12].Id.ToString("B")), new XElement("Value", employee.FirstName)) //First Name
                                )
                         );
