       Try using this piece of code.
     excelworkBook.SaveAs(saveAsLocation);
     excelworkBook.Close();
     excel.Quit();
     bool flag=SaveAsPdf(saveAsLocation);
