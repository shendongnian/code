    public void AccountUpdate(string id, string username, string password, string position) {
    //remove it AccountID();
        result.Query="Update tbl_account set username='"+username+"', password='"+password+"', position='"+position+"' where id="+id;
    //even your id is string if you remove the quote in your where clause, it will still treat as int
        result.Transaction = true;
        result.ExecuteNonQuery();
        AccountCommit();
        result.Close();
    }
