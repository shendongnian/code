    namespace SeleniumTestDriver
    {
       class Program
       {
        
        static void Main(string[] args)
        {
            StringDictionary testData = new StringDictionary();
            testData = GetTestData();
            IWebDriver driver = new InternetExplorerDriver();
            driver.Navigate().GoToUrl("http://toolsqa.com/automation-practice-form/");
            driver.Manage().Window.Maximize();
            IWebElement txtbxFirstName = driver.FindElement(By.Name("firstname"));
            txtbxFirstName.SendKeys(testData["firstName"]);
    }
    public static StringDictionary GetTestData()
        {
            StringDictionary dataFromExcel = new StringDictionary();
            Excel.Application xlApp = new Excel.Application();
            xlApp.Visible = false;
            Excel.Workbook xlWb = xlApp.Workbooks.Open(@"C:\Users\...\Desktop\1.xlsx");
            Excel.Worksheet xlSht1 = xlWb.Worksheets.get_Item(2);
            dataFromExcel.Add("firstName", xlSht1.Cells[2, 1].value);
            dataFromExcel.Add("lastName", xlSht1.Cells[2, 2].value);
            dataFromExcel.Add("gender", xlSht1.Cells[2, 3].value);
            dataFromExcel.Add("tool", xlSht1.Cells[2, 4].value);
            dataFromExcel.Add("continent", xlSht1.Cells[2, 5].value);
            xlWb.Close();
            xlApp.Quit();
            return dataFromExcel;
           
        }
     }
    }
