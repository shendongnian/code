        Console.WriteLine("***************Loading External assembly*************");
            Assembly assembly = Assembly.LoadFrom(@"CXXXXXX\ClassLibrary1\bin\Debug\ClassLibrary1.dll");
            Type employeeType = assembly.GetType("DelegatesSampleApplication.Employee"); //Gets the System.Type object for the Employee Class from the just loaded assembly with all it's dependencies
            object employeeInstance = Activator.CreateInstance(employeeType);//Create an instance of the Employee Class Type
            Console.WriteLine("***************Loading External assembly properties*************");
            PropertyInfo[] propertyInfoColl =  employeeType.GetProperties();
            foreach(var item in propertyInfoColl)
            {
                Console.WriteLine("Loaded Type Property Name {0} and default value {1}", item.Name, item.GetValue(employeeInstance, null));
            }
            Console.WriteLine("***************Setting External assembly propeties for the first instance*************");
            PropertyInfo employeeId = (PropertyInfo)employeeType.GetProperty("EmployeeId");
            employeeId.SetValue(employeeInstance, 1);
            Console.WriteLine("Employee Id Property value now set to " + employeeId.GetValue(employeeInstance,null));
            PropertyInfo employeeName = (PropertyInfo)employeeType.GetProperty("EmployeeName");
           employeeName.SetValue(employeeInstance, "A");
            Console.WriteLine("Employee Name Property value now set to " + employeeName.GetValue(employeeInstance, null));
            PropertyInfo salary = (PropertyInfo)employeeType.GetProperty("Salary");
            salary.SetValue(employeeInstance, 40000);
            Console.WriteLine("Salary Property value now set to " + salary.GetValue(employeeInstance, null));
            PropertyInfo experience = (PropertyInfo)employeeType.GetProperty("Experience");           
            experience.SetValue(employeeInstance, 3);
            Console.WriteLine("Experience Property value now set to " + experience.GetValue(employeeInstance, null));
            Console.WriteLine("***************Setting External assembly propeties for the second instance*************");
            object employeeInstance2 = Activator.CreateInstance(employeeType);
            PropertyInfo employeeId2 = (PropertyInfo)employeeType.GetProperty("EmployeeId");
            employeeId2.SetValue(employeeInstance2, 2);
            Console.WriteLine("Employee Id Property value now set to " + employeeId2.GetValue(employeeInstance2, null));
            PropertyInfo employeeName2 = (PropertyInfo)employeeType.GetProperty("EmployeeName");
            employeeName2.SetValue(employeeInstance2, "B");
            Console.WriteLine("Employee Name Property value now set to " + employeeName2.GetValue(employeeInstance2, null));
            PropertyInfo salary2 = (PropertyInfo)employeeType.GetProperty("Salary");
            salary2.SetValue(employeeInstance2, 50000);
            Console.WriteLine("Salary Property value now set to " + salary2.GetValue(employeeInstance2, null));
            PropertyInfo experience2 = (PropertyInfo)employeeType.GetProperty("Experience");
            experience2.SetValue(employeeInstance2, 6);
            Console.WriteLine("Experience Property value now set to " + experience2.GetValue(employeeInstance2, null));
            Console.WriteLine("***************Creating an array list that will hold these employee instances***************");
           
            /// list creation goes here 
            var listType = typeof(List<>);
            var constructedListType = listType.MakeGenericType(employeeType);
            var employeeInstanceListType = Activator.CreateInstance(constructedListType);
            var employeeInstanceListInstance = (IList)Activator.CreateInstance(constructedListType);
            employeeInstanceListInstance.Add(employeeInstance);
            employeeInstanceListInstance.Add(employeeInstance2);
            Console.WriteLine("***************Invoking External assembly methods*************");
            //var agrsDel = new Object[] {(employeeInstance) => return employeeInstance};         
            Delegate validationDelegate;
            try
            {
                Type prog = assembly.GetType("DelegatesSampleApplication.Program");
                Type delegateType = assembly.GetType("DelegatesSampleApplication.IsPromotable");
                // Convert the Arg1 argument to a method
                MethodInfo mi = prog.GetMethod("EnableToPromote",
                BindingFlags.Public | BindingFlags.Static);
                // Create a delegate object that wraps the static method
                validationDelegate = Delegate.CreateDelegate(delegateType, mi);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Phew... not working" );
                return;
            }
          
            dynamic value = employeeType.InvokeMember("PromoteEmployees", BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public, null, employeeInstance, new Object[] { employeeInstanceListInstance, validationDelegate });
         
