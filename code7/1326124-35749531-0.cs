    namespace CodedUITestProject1
    {
        [CodedUITest]
        public class CodedUITest1
        {
           int currentIteration =0;
            public static string ProjectName = Assembly.GetCallingAssembly().GetName().Name;
            public static string sFileName = string.Concat(@"C:\Results\", ProjectName + '\\' + DateTime.Today.ToString("dd_MMM_yyyy"), '\\', DateTime.Now.ToString("ddMMMhhmmtt")+ "_", "Result");
            public static Dictionary<string, string> ResultsKey = new Dictionary<string, string>();
            public CodedUITest1()
            {
                if (!Directory.Exists(sFileName))
                {
                    Directory.CreateDirectory(sFileName);
                }
            }
         }
    }
