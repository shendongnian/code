         var mySheet = Path.Combine(Directory.GetCurrentDirectory(), "Sample.xlsx");
              Excel.Application xlApp = new Excel.Application();
              xlApp.Visible = true;
              if (xlApp == null)
              {
                  MessageBox.Show("Excel is not properly installed!!");
                  return;
              }
              try
              {
                  Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(mySheet);
              }
              catch(Exception ex)
              {
                  xlApp.Quit();
                 
              }
