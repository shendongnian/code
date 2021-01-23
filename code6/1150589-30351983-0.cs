    BasvuruMaster[] BasVurList = new BasvuruMaster[ds.Tables[0].Rows.Count];
    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    {
          if (ds.Tables.Count > 0)
          {
            BasVurList[i] = new BasVurList(); <-- HERE
            BasVurList[i].Tarih = ds.Tables[0].Rows[i + 1].ItemArray[0].ToString();
            BasVurList[i].Icerik = ds.Tables[0].Rows[i+1].ItemArray[1].ToString();
            BasVurList[i].RefNo = ds.Tables[0].Rows[i+1].ItemArray[2].ToString();
          }
    } 
