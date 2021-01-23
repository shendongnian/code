    var mailInfoList = new List<Tuple<string, string, string, string, string, DateTime>>();
	if (ds.Tables[0].Rows.Count > 0)
	{
		foreach (DataRow row in ds.Tables[0].Rows)
		{
			string strSubject = row["Subject"].ToString();
			string strEmailFrom = row["EmailFrom"].ToString();
			string strEmailTo = row["EmailTo"].ToString();
			string strEmailCC = row["EmailCc"].ToString();
			string strEmailContent = row["EmailContent"].ToString();
			// Do proper error handling here
			DateTime strCreatedOn = DateTime.Parse(row["CreatedOn"].ToString());
			mailInfoList.Add(new Tuple<string, string, string, string, string, DateTime>(
				strSubject, strEmailFrom, strEmailTo, strEmailCC, strEmailContent, strCreatedOn
				));
			
			var newList = mailInfoList.OrderBy(x => x.Item1).ThenBy(x => x.Item6).ToList();
		}
	}
