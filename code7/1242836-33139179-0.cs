                var query =
                           from wr in db.Ward_Req
                           join w in db.Wards
                           on wr.WARD_ID equals w.WARD_ID
                           join rl in db.Req_Line
                           on wr.REQ_ID equals rl.REQ_ID
                           join m in db.Materials
                           on rl.ITEM_ID equals m.ITEM_ID
                           where wr.STATUS == "C"
                           orderby w.WARD_NAME descending
                           select new Reports
                           {
                               WARD_NAME = w.WARD_NAME,
                               WARD_LOCATION = w.WARD_LOCATION,
                               ITEM_ID = m.ITEM_ID,
                               ITEM_TYPE = m.ITEM_TYPE,
                               ITEM_NAME = m.ITEM_NAME
                           };
                switch (strSortBy)
                {
                    case "WardName":
                        query = query.OrderBy(s => s.WARD_NAME);
                        break;
                    case "WardLocation":
                        query = query.OrderBy(s => s.WARD_LOCATION);
                        break;
                    case "ItemID":
                        query = query.OrderBy(s => s.ITEM_ID);
                        break;
                    case "ItemType":
                        query = query.OrderBy(s => s.ITEM_TYPE);
                        break;
                    case "ItemName":
                        query = query.OrderBy(s => s.ITEM_NAME);
                        break;
                    default:
                        break;
                }
                return View(query.ToList());
