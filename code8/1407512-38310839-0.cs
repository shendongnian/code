    public async Task InvokeAllTheSqlAsync()
    {
        var tasks = 
            Enumerable.Range(0,
                gm.ListGroupMembershipUploadDetailsInput
                  .GroupMembershipUploadInputList
                  .Count)
                      .Select(i =>
                {
                    var value = 
                        gm.ListGroupMembershipUploadDetailsInput
                          .GroupMembershipUploadInputList[i];
                    string strSPQuery;
                    List<SqlParameter> listParam;
                    SQL.Upload.UploadDetails.insertGroupMembershipRecords(
                            value, 
                            max_seq_key++,
                            max_unit_key++,
                            out strSPQuery,
                            out listParam);
    
                        return rep.ExecuteStoredProcedureInputTypeAsync(strSPQuery, listParam);
                    });
        await Task.WhenAll(tasks);  
    }
