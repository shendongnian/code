    public async Task InvokeAllTheSqlAsync()
    {
        var list = gm.ListGroupMembershipUploadDetailsInput.GroupMembershipUploadInputList;
        var tasks = Enumerable.Range(0, list.Count).Select(i =>
        {
            var value = list[i];
            string strSPQuery;
            List<SqlParameter> listParam;
            SQL.Upload.UploadDetails.insertGroupMembershipRecords(
                value, 
                max_seq_key++,
                max_unit_key++,
                out strSPQuery,
                out listParam
            );
            
            return rep.ExecuteStoredProcedureInputTypeAsync(strSPQuery, listParam);
        });
        await Task.WhenAll(tasks);
    }
