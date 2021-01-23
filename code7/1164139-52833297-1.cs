            DataSet dsIndexchange = new DataSet();
            DataTable dtdummysummary = new DataTable();
            dtdummysummary = dsAssetInterval.Tables[dsAssetInterval.Tables.Count-1];
            dsAssetInterval.Tables.RemoveAt(dsAssetInterval.Tables.Count-1);
            dsIndexchange.Tables.Add(dtdummysummary);
            for (int i = 0; i < dsAssetInterval.Tables.Count; i++)
            {
                dsIndexchange.Tables.Add(dsAssetInterval.Tables[i].Copy());
            }
