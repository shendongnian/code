    Dictionary<string, string> tests = new Dictionary<string, string>();
    
    foreach (DataRow row in dt.Rows)
    {
        var testName = (string)row["TestName"];
        var testResult = (string)row["TestResult"];
    
        if (!tests.ContainsKey(testName))
            tests.Add(testName, testResult);
    }
    
    string json = Newtonsoft.Json.JsonConvert.SerializeObject(tests);
