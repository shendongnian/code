            using (var conn = new DB.Entities())
            {
                var stories = (from a in conn.Subscribers
                               orderby a.DT descending
                               select a).Take(100).ToList();
                var ShowHeader = true;
                PropertyInfo[] properties = stories.First().GetType().GetProperties();
                List<string> headerNames = properties.Select(prop => prop.Name).ToList();                
                var wb = new XLWorkbook();
                var ws = wb.Worksheets.Add("Subscribers");
                if (ShowHeader)
                {
                    for (int i = 0; i < headerNames.Count; i++)                    
                        ws.Cell(1, i + 1).Value = headerNames[i];
                                        
                    ws.Cell(2, 1).InsertData(stories);
                }
                else
                {
                    ws.Cell(1, 1).InsertData(stories);
                }
               
                wb.SaveAs(@"C:\Testing\yourExcel.xlsx");
            }
