    static void Main(string[] args)
    {
        Type ORType = Type.GetTypeFromProgID("Mercury.ObjectRepositoryUtil"); 
        dynamic ORUtil = Activator.CreateInstance(ORType);
        string ORFilePath = @"D:\TAF\Size.tsr";
        //ObjectRepositoryUtil ORUtil = new ObjectRepositoryUtil();
        ORUtil.Load(ORFilePath);
        var ChildObjects = ORUtil.GetChildren();
        for (int i = 0; i < ChildObjects.Count(); i++ )
        {
            var ChildObject = ChildObjects.Item(i);
            string title = ChildObject.GetTOProperty("micclass") + "(\"" + ORUtil.GetLogicalName(ChildObject) + "\")";
            Console.WriteLine(title);
        }
    }
