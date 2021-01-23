     Console.Write("Path: ");
     var path = Console.ReadLine();
     var dirInfo = new DirectoryInfo(path);
     while (string.IsNullOrWhiteSpace(path) || !dirInfo.Exists)
     {
         Console.WriteLine("Invalid path");
         Console.Write("Path: ");
         path = Console.ReadLine();
         dirInfo = new DirectoryInfo(path);
     }
     string[] files = null;
     try
     {
         files = Directory.GetFiles(path, "*.xlsx", SearchOption.AllDirectories);
     }
     catch (Exception ex)
     {
         Console.WriteLine(ex.Message);
         Console.ReadLine();
         return;
     }
     Console.WriteLine("{0} files found.", files.Length);
     if (files.Length == 0)
     {
         Console.ReadLine();
         return;
     }
     int succeded = 0;
     int failed = 0;
     Action<string> LoadToDataSet = (filePath) =>
     {
         try
         {
             FileInfo fileInfo = new FileInfo(filePath);
             using (ExcelPackage excel = new ExcelPackage(fileInfo))
             using (DataSet dataSet = new DataSet())
             {
                 int workSheetCount = excel.Workbook.Worksheets.Count;
                 for (int i = 1; i <= workSheetCount; i++)
                 {
                     var worksheet = excel.Workbook.Worksheets[i];
                     var dimension = worksheet.Dimension;
                     if (dimension == null)
                         continue;
                     bool hasData = dimension.End.Row >= 1;
                     if (!hasData)
                         continue;
                     DataTable dataTable = new DataTable();
                     //add columns
                     foreach (var firstRowCell in worksheet.Cells[1, 1, 1, dimension.End.Column])
                     dataTable.Columns.Add(firstRowCell.Start.Address);
                     for (int j = 0; j < dimension.End.Row; j++)
                         dataTable.Rows.Add(worksheet.Cells[j + 1, 1, j + 1, dimension.End.Column].Select(erb => erb.Value).ToArray());
                     dataSet.Tables.Add(dataTable);
                 }
                 dataSet.Clear();
                 dataSet.Tables.Clear();
             }
             Interlocked.Increment(ref succeded);
         }
         catch (Exception)
         {
             Interlocked.Increment(ref failed);
         }
     };
     Stopwatch sw = new Stopwatch();
            
     sw.Start();
     files.AsParallel().ForAll(LoadToDataSet);
     sw.Stop();
     Console.WriteLine("{0} succeded, {1} failed in {2} seconds", succeded, failed, sw.Elapsed.TotalSeconds);
     Console.ReadLine();
