    public void Main()
    {
        try
        {
            List<TestModel> testModelList = BuildObjectList();
            TestModel testModel = new TestModel();
            testModel.prop1 = "new prop";
            testModel.prop2 = true;
            testModelList.Add(testModel);
            
            Dts.TaskResult = (int)ScriptResults.Success;
        }
        catch
        {
            Dts.TaskResult = (int)ScriptResults.Failure;
        }
    }
    private List<TestModel> BuildObjectList()
    {
        try
        {
            List<TestModel> RunningList = new List<TestModel>();
            TestModel localModel = new TestModel();
            var data = Dts.Variables["User::myObjectList"].Value;
            IEnumerable enumDataList = (IEnumerable)data;
            foreach (var currentObj in enumDataList)
            {
                localModel = GetSingleResult(currentObj);
                RunningList.Add(localModel);
                localModel = new TestModel();
            }
            return RunningList;
        }
        catch
        {
            return new List<TestModel>();
        }
    }
    private TestModel GetSingleResult(object currentObj)
    {
        try
        {
            TestModel returnedResult = new TestModel();
            PropertyInfo[] properties = currentObj.GetType().GetProperties();
            foreach (PropertyInfo pi in properties)
            {
                switch (pi.Name)
                {
                    case "prop1":
                        returnedResult.prop1 = pi.GetValue(currentObj, null).ToString();
                        break;
                    case "prop2":
                        returnedResult.prop2 = Convert.ToBoolean(pi.GetValue(currentObj, null));
                        break;
                    default:
                        break;
                }
            }
            return returnedResult;
        }
        catch {
            return new TestModel();
        }
    }
    internal class TestModel
    {
        internal string prop1 { get; set; }
        internal bool prop2 { get; set; }
    }
