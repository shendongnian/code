    TestForm t = new TestForm(); // this ONLY creates a NEW form in memory
    // if you were looking at a TestForm already t holds a new form
    // and not the one you're looking at.
    var returnValue = new DataTable();
    var conn = new SqlConnection(ConnectionString._connectionString);
    // the form is not shown to the user at this point
    // and never will be because YOU didn't tell it to Show
    // The textbox is empty
    string st = t.sql1.Text;
    // st will be an empty string here
