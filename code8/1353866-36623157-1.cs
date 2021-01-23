    using System;
	using System.Text;
	using System.Collections.Generic;
	using System.Linq;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using OpenQA.Selenium.IE;
	using OpenQA.Selenium.Remote;
	using OpenQA.Selenium;
	using OpenQA.Selenium.Interactions;
	using OpenQA.Selenium.Support.UI;
	using OpenQA.Selenium.Chrome;
	using System.Reflection;
	using System.IO;
	using System.Collections.ObjectModel;
	namespace VerifySorting
	{
		/// <summary>
		/// Summary description for UnitTest1
		/// </summary>
		[TestClass]
		public class UnitTest1
		{
			public UnitTest1()
			{
				//
				// TODO: Add constructor logic here
				//
			}
			private TestContext testContextInstance;
			private RemoteWebDriver driver;
			/// <summary>
			///Gets or sets the test context which provides
			///information about and functionality for the current test run.
			///</summary>
			public TestContext TestContext
			{
				get
				{
					return testContextInstance;
				}
				set
				{
					testContextInstance = value;
				}
			}
			#region Additional test attributes
			//
			// You can use the following additional attributes as you write your tests:
			//
			// Use ClassInitialize to run code before running the first test in the class
			// [ClassInitialize()]
			// public static void MyClassInitialize(TestContext testContext) { }
			//
			// Use ClassCleanup to run code after all tests in a class have run
			// [ClassCleanup()]
			// public static void MyClassCleanup() { }
			//
			// Use TestInitialize to run code before running each test 
			// [TestInitialize()]
			// public void MyTestInitialize() { }
			//
			// Use TestCleanup to run code after each test has run
			[TestCleanup()]
			public void MyTestCleanup() {
				this.driver.Quit();
			}
		
			#endregion
	
			[TestMethod]
			public void ChromeDriverTest()
			{
				ChromeOptions chromeOptions = new ChromeOptions();
				string name = Assembly.GetExecutingAssembly().Location;
				string dir = Path.GetDirectoryName(name);
				int index = 0;
				bool isAsc = true, isDesc = true;
				string expr;
				#region Driver instantiation and navigation to the test page
				RemoteWebDriver driver = new ChromeDriver(dir + "\\..\\..\\driver", chromeOptions);
				this.driver = driver;
				driver.Navigate().GoToUrl(dir + "\\..\\..\\page.htm");
				#endregion // Driver instantiation and navigation to the test page
				#region Finding elements on page and sorting
				IWebElement grid = driver.FindElementById("grid1");
				IWebElement thead = grid.FindElement(By.TagName("thead"));
				ReadOnlyCollection<IWebElement> ths = thead.FindElements(By.XPath("tr/th"));
				ths[index].Click();
				IWebElement tbody = grid.FindElement(By.TagName("tbody"));
				ReadOnlyCollection<IWebElement> trs = tbody.FindElements(By.TagName("tr"));
				List<IWebElement> tds = new List<IWebElement>();
				for (int i = 0; i < trs.Count; i++)
				{
					tds.Add(trs[i].FindElement(By.XPath("td[" + (index + 1) + "]")));
				}
				#endregion // Finding elements on page and sorting
				#region Verification of the sort order
				int count = tds.Count;
				for (int i = 1; i < count; i++)
				{
					if (tds[i - 1].Text.CompareTo(tds[i].Text) < 0)
					{
						isDesc = false;
						break;
					}
				}
				for (int i = 1; i < count; i++)
				{
					if (tds[i - 1].Text.CompareTo(tds[i].Text) > 0)
					{
						isAsc = false;
						break;
					}
				}
				Assert.IsTrue(isAsc || isDesc, "The column is not sorted.");
				#endregion // Verification of the sort order
				#region UI verifications
				expr = driver.ExecuteScript("return $('#grid1').data('igGrid').dataSource.settings.sorting.expressions[0].dir").ToString();
				if (isAsc)
				{
					Assert.IsTrue(expr == "asc");
					Assert.IsTrue(ths[index].GetAttribute("title") == "Sorted ascending");
					Assert.IsTrue(ths[index].GetAttribute("class").Contains("ui-iggrid-colheaderasc"));
					Assert.IsTrue(ths[index].GetAttribute("class").Contains("ui-iggrid-sortableheader"));
					Assert.IsTrue(ths[index].FindElement(By.XPath("div/span")).GetAttribute("class").Contains("ui-iggrid-colindicator-asc"));
				
					for (int i = 0; i < tds.Count; i++)
					{
						Assert.IsTrue(tds[i].GetAttribute("class").Contains("ui-iggrid-colasc ui-state-highlight"));
					}
				}
				if (isDesc)
				{
					Assert.IsTrue(expr == "desc");
					Assert.IsTrue(ths[index].GetAttribute("title") == "Sorted descending");
					Assert.IsTrue(ths[index].GetAttribute("class").Contains("ui-iggrid-colheaderdesc"));
					Assert.IsTrue(ths[index].GetAttribute("class").Contains("ui-iggrid-sortableheader"));
					Assert.IsTrue(ths[index].FindElement(By.XPath("div/span")).GetAttribute("class").Contains("ui-iggrid-colindicator-desc"));
					for (int i = 0; i < tds.Count; i++)
					{
						Assert.IsTrue(tds[i].GetAttribute("class").Contains("ui-iggrid-coldesc ui-state-highlight"));
					}
				}
				#endregion // UI verifications
			}
		}
	}
