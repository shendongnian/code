    if (saveFileDialog1.FileName != "")
        {
          var app = new Application();
          var wb = app.Workbooks.Add();
          switch (saveFileDialog1.FilterIndex)
             {
                case 1:
                   wb.SaveAs(saveFileDialog1.FileName);
                   break;    
                case 2:
                   wb.SaveAs(saveFileDialog1.FileName, XlFileFormat.xlExcel8);
                            break;
             }
          wb.Close();
          app.Quit();
                   
          ExportDataSetToExcel(_destinationDataSet, saveFileDialog1.FileName);
        }
