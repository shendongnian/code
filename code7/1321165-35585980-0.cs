	var query = xdoc.Descendants("Process")
		.Select(x=> new Process()
			{
				Code = x.Element("Number").Value,
				Progresses = new List<Progress>(
					x.Elements("Progress").Select(y=> new Progress
						{
							ProgressDate = y.Element("Date").Value,
							Text = y.Element("Text").Value
						})
					)
			});
