    var yearMon = dtfm.Rows[0].ToString().Substring(0,4);
    if (yearMon == DateTime.Now.ToString("yyMM")) {
        no = dtfm.Rows[0] + 1; //assuming the database column is an int and not a varchar
    } else {
        no = Int32.Parse(DateTime.Now.ToString("yyMM001"));
    }
    return no;
