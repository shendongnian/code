        public static IEnumerable<EmployeeContainer> GetAllEmployees()
        {
            return new[] { 
                new EmployeeContainer { 
                    Employees = 
                        new[] { 
                            new Employee { name = "John", lastname = "Coleman", age = 42, someMoreDataThatShouldNotBeSerialized = "someMoreData1" },
                            new Employee { name = "Chip", lastname = "Dale", age = 26, someMoreDataThatShouldNotBeSerialized = "someMoreData2" },
                        } 
                },
                new EmployeeContainer { 
                    Employees = 
                        new[] { 
                            new Employee { name = "Ann", lastname = "Smith", age = 33, someMoreDataThatShouldNotBeSerialized = "someMoreData3" },
                            new Employee { name = "Terry", lastname = "Johnson", age = 24, someMoreDataThatShouldNotBeSerialized = "someMoreData4" }, 
                        } 
                },
                new EmployeeContainer()
            };
        }
