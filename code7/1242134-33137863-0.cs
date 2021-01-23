            if (Vendors == null) { Vendors = ""; }
                if(Vendors == "") { Vendors = DBNull.Value.ToString(); }
                
                var @Vendor = new SqlParameter("@Vendor", Vendors);
                string query = "SELECT V.VENDOR_NAME, SUM(POL.ORDER_QTY * POL.UNIT_PRICE) AS AMOUNT_SPENT, MONTH(PO.ORDER_DATE) AS MO, YEAR(PO.ORDER_DATE) AS YR, M.ITEM_TYPE AS ITEM_TYPE "
                    + "FROM PO_LINE POL "
                    + "JOIN PURCH_ORD PO ON PO.PO_NUM = POL.PO_NUM "
                    + "JOIN VENDOR V ON V.VENDOR_ID = PO.VENDOR_ID "
                    + "JOIN MATERIAL M ON M.ITEM_ID = POL.ITEM_ID ";
                if (Vendors != "")
                {
                    query += "WHERE V.VENDOR_NAME = @Vendor ";
                }
            
                query += "GROUP BY V.VENDOR_NAME, M.ITEM_TYPE, YEAR(PO.ORDER_DATE), MONTH(PO.ORDER_DATE) "
                    + "ORDER BY V.VENDOR_NAME";
                         
                if (Vendors != "")
                {
                    var data = db.Database.SqlQuery<Reports>(query, @Vendor);
                    return View(data.ToList());
                }
                else
                {
                    var data = db.Database.SqlQuery<Reports>(query);
                    return View(data.ToList());
                }
