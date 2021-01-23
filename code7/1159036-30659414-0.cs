           string testAssemblyPath = "Assembly Path"; // Make sure only path and do not specify the assembly name.
            using (ExcelPackage p = new ExcelPackage())
            {
                using (FileStream stream = new FileStream(@"ExcelFilePath.xlsx", FileMode.Open))
                {
                    p.Load(stream);
                    ExcelWorksheet ws = p.Workbook.Worksheets["Sheet1"];
                    int rowIndex = 2;
                    for (int index = 0; index < ws.Dimension.Rows - 1; index++)
                    {
                        if ("Yes" == ws.Cells[rowIndex + index, 3].Value.ToString())
                        {
                            string className = ws.Cells[rowIndex + index, 1].Value.ToString();
                            string methodName = ws.Cells[rowIndex + index, 2].Value.ToString();
                            Assembly assembly = Assembly.LoadFrom(testAssemblyPath + "TestAssembly.dll");
                            Type type = assembly.GetType(string.Concat(assembly.FullName.Split(',')[0], className));
                            if (type != null)
                            {
                                MethodInfo methodInfo = type.GetMethod(methodName);
                                if (methodInfo != null)
                                {                                    
                                    object classInstance = Activator.CreateInstance(type, null);
                                    methodInfo.Invoke(classInstance, null);
                                }
                            }
                        }
                    }
                }
            }
