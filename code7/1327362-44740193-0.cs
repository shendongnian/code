        private void insertImageFileToMemo(String memoId)
        {
            var dbe = new DBEngine();
            Database db = dbe.OpenDatabase(@"D:\yourdatabase.accdb");
            try
            {
                Recordset rstMain = db.OpenRecordset(
                        "SELECT memoId,memoImage FROM MyMemo WHERE MemoID = '" + memoId + "'",
                        RecordsetTypeEnum.dbOpenDynaset);
                rstMain.Edit();
                Recordset2 rstAttach = rstMain.Fields["memoImage"].Value;
                rstAttach.AddNew();
                Field2 fldAttach = (Field2)rstAttach.Fields["FileData"];
                fldAttach.LoadFromFile("memofile1.jpg");
                rstAttach.Update();
                rstAttach.Close();
                rstMain.Update();
                rstMain.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
