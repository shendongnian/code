	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	using System.Diagnostics;
	using Newtonsoft.Json;
	namespace TestWebService {
		public class LoadService {
			public ArrayList getTestUser() {
				TestWebService.TestWeb.QAAWS_by_USER test1 = new
				TestWebService.TestWeb.QAAWS_by_USER();
				String message, creatorname, creationdateformatted, description, universe;
				DateTime creationdate;
				int queryruntime, fetchedrows;
				TestWebService.TestWeb.Row[] row = test1.runQueryAsAService(("<username>", "<password>", out message, out creatorname, out creationdate, out creationdateformatted, out description, out universe, out queryruntime, out fetchedrows);
				int resultCount = row.Length;
				var index = 0;
				var list = new ArrayList();
				for (int i = 0; i < resultCount; i++) {
					getUserInformation userInformation = new getUserInformation {
						User_name = row[i].User,
						Owed_value = row[i].Owed
					};
					list.Add(userInformation);
					index++;
				}
				return list;
			}
		}
		public class getUserInformation {
			public string User_name { get; set; }
			public double Owed_value { get; set; }
		}
	}
