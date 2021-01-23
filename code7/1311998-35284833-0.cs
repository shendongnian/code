    from t in db.PUTAWAYs
    join t0 in db.ASN_ITEM on t.AWB_NO equals t0.AWB_NO
    join t1 in db.ASN_MASTER on t0.AWB_NO equals t1.AWB_NO
    join t2 in db.ITEM_MASTER on t.ITEM_MASTER.ITEM_CODE equals t2.ITEM_CODE
    join t3 in db.ASN_INPUT on t0.AWB_NO equals t3.AWB_NO
    where
      t3.ITEM == t2.ITEM_CODE &&
      1 == 1 &&                          
      (fromDate == "" || toDate == "" || (t0.REC_DATE.CompareTo(fromDate) >= 0 && t0.REC_DATE.CompareTo(toDate) <= 0)) &&
      (AWB_NO == "" || (t0.AWB_NO == AWB_NO))
    orderby
      t.AWB_NO,
      t0.REC_DATE,
      t0.STYPE,
      t2.PART_NO
    select new ASNPutawayRep
    {
        AWB_NO = t.AWB_NO,
        REC_DATE = t0.REC_DATE,
        STYPE = t0.STYPE,
        PART_NO = t2.PART_NO,
        LOCATION_AD = (from l in db.LOCATION_MASTER 
                         where l.LOC_CODE = t.LOCATION_AD
                         select LocName).AsQueryable().FirstorDefault(),
        QNTY = t.QNTY,
        LOCATION_SD = (from l in db.LOCATION_MASTER 
                         where l.LOC_CODE = t.LOCATION_SD
                         select LocName).AsQueryable().FirstorDefault(),
        REGION_ID = t.REGION_ID
    }).Distinct();
