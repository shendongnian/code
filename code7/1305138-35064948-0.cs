	public void GenerateChart(string modelAsString)
	{
		List<Bar> model = new List<Bar>();
		model = JsonConvert.DeserializeObject<List<Bar>>(modelAsString);
		var chart = new System.Web.Helpers.Chart(400, 200)
		.AddTitle("Title")
		.AddSeries(
			name: "name",
			xValue: model.Select(m => m.BarA).ToArray(),
			yValues: model.Select(m => m.BarB).ToArray())
		.Write();
	}
