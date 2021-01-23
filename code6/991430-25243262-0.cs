    using (StringWriter stringWriter = new StringWriter())
    {
		Console.SetOut(stringWriter);
        NUnit.ConsoleRunner.Runner.Main(new string[]
        {
            System.Reflection.Assembly.GetExecutingAssembly().Location,
            "OpenShop_Firefox.dll"
        });
        string allConsoleOutput = stringWriter.ToString();
    }
