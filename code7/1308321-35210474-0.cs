    worksheet.UsedRange.Item[rowNo,getColumnIndex(worksheet,columnTitle)]=value
    private int getColumnIndex(Excel.Worksheet sheetname, string header) {
            int index=0;
            Excel.Range activeRange=sheetname.UsedRange;
            for (int i = 1; i <= activeRange.Columns.Count; i++) {
                if (header == (string)(activeRange.Item[1,i] as Excel.Range).Value) {
                    index = i;
                }
            }
            if(index==0)
                throw some exception you like;
            return index;
        }
