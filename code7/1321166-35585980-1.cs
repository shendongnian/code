	var query = xdoc.Descendants("Process")
	.Select(x=> new Process
		{
			Code = x.Element("Number").Value,
			Progresses = x.Descendants("Progress")
				.SelectMany((ele, j)=>  ele.Elements("Date").Select((a, i)=>new{Date = a.Value, Index = i+(j*10)}))
				.Join(x.Descendants("Progress").SelectMany((ele, j)=> ele.Elements("Text").Select((a, i)=>new{Text = a.Value, Index = i+(j*10)})),
						dat => dat.Index,
						tex => tex.Index,
						(dat, tex) => new {D = dat, T = tex})
				.Select(jdata=> new Progress
					{
						//Index = jdata.D.Index,
						ProgressDate = jdata.D.Date,
						Text = jdata.T.Text
					}).ToList<Progress>()
		});
