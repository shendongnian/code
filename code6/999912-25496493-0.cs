    public static List<SPCDataSeqCntInfo> GetSPCDataSeqCntInfo(DateTime dateParam, string lineCode, int modelNum, int equipmentNumber, int lotNum)
    {
        using (var db = new NameOfMyEntites())
        {
            return db.sp_GetSPCDataSeqCntInfo(dateParam, lineCode, modelNum, equipmentNumber, lotNum).ToList();
        }
    }
