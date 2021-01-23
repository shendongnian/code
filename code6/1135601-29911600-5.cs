    var workbook = workbooks.Open(fileName,
                    Type.Missing, false, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
    if (workbook.ReadOnly){
      // is probably opened by another process;
    }
