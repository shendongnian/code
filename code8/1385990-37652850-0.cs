    var affectedTestCases = (from testCase in TestCaseList.ListOfTestCases
      where testCase.TestHash==CurrentFile.Hash
      select testCase).ToList();
    ScriptEditor.Save(filePath);// this changes CurrentFile.Hash
    foreach (var affectedTestCase in affectedTestCases2)
    {
      int index = TestCaseList.ListOfTestCases.IndexOf(affectedTestCase);
      TestCaseList.ListOfTestCases[index].TestHash = CurrentFile.Hash;
    }
