    private void AddSomethingToTable(string tablename, string fieldname) {
      try {
        InsertFieldToTable(tablename, fieldname);
      } catch (Exception ex) {
        string str = string.Format("Could not insert field '{0}' into table '{1}'", fieldname, tablename);
        throw new Exception(str, ex);
      }
}
