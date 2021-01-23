    !t.AWB_NO.Contains((from t2 in db.ASN_ITEM
                    where
                     t2.SCAN_STAT != 2
                        select new {
                         t2.AWB_NO
                        }).Distinct()) 
