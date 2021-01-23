    public static Image GetImage(string sheetname, ExcelPackage excelFile)
        {
          var sheet = excelFile.Workbook.Worksheets[sheetname];
          var pic = sheet.Drawings["pic_001"] as ExcelPicture;
          return pic.Image;
        }
