    private bool SaveAsPdf(string saveAsLocation)
      {
        string saveas = (saveAsLocation.Split('.')[0]) + ".pdf";
          try
            {
              Workbook workbook = new Workbook();
              workbook.LoadFromFile(saveAsLocation);
        
              //Save the document in PDF format
                        
              workbook.SaveToFile(saveas, Spire.Xls.FileFormat.PDF);
              return true;
            }
           catch (Exception ex)
             {
               MessageBox.Show(ex.Message);
               return false;
             }
      }
