                if (!File.Exists(sPathTestData))
                {
                    Directory.CreateDirectory(path);
                try
                {
                    ExcelUtils.createExcelFile(sPathTestData, sheet);
                }
                catch (FileNotFoundException fe)
                {
                    Console.WriteLine("Unable to Create File. Exception is : " + fe);
                }
               }
                else
                {
                try
                {
                    ExcelUtils.setExcelFile(sPathTestData, sheet);
                }
                catch (FileNotFoundException fe)
                {
                    Console.WriteLine("Unable to Load File. Exception is : " + fe);
                }
                }
