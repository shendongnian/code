TestWebService.asmx.cs
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web;
	using System.Web.Services;
	using Newtonsoft.Json;
	namespace TestWebService {
		/// <summary>
		/// Summary description for TestService
		/// </summary>
		[WebService(Namespace = "http://tempuri.org/")]
		[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
		[System.ComponentModel.ToolboxItem(false)]
		// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
		// [System.Web.Script.Services.ScriptService]
		public class TestService : System.Web.Services.WebService {
			private LoadService user;
			public TestService() {
				this.user = new LoadService();
			}
			[WebMethod]
			public string TestResult() {
				ArrayList list = this.user.getTestUser();
				return JsonConvert.SerializeObject(list);
			}
		}
	}
