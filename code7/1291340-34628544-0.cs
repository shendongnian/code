                foreach (var itm in voucherList)
                {
                    DataRow row = dt.NewRow();
                    row["VoucherUid"] = itm.Uid;
                    row["ClientUid"] = itm.ClientUid;
                    row["BatchUid"] = itm.BatchUid;
                    row["CardNo"] = itm.CardNo;
                    row["Origin"] = itm.Origin;
                    row["VoucherCreateDate"] = itm.VoucherCreateDate;
                    row["State"] = itm.State;
                    row["LastTimeStamp"] = SqlDbType.Timestamp; //Here
                    dt.Rows.Add(row);
                }
