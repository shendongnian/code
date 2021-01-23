    ArrayList aryTest = new ArrayList();
    aryTest.Add("1");
    aryTest.Add("2");
    aryTest.Add("3");
    string strTest = "";
    foreach (var a in aryTest)
    {
    strTest += a +"#";
    }
    strTest.TrimEnd(new char[] {'#'});
