	[TestMethod]
	public void Check_Multi_Test()
	{
		Int32 chartPaddingX = 50;
		Int32 chartPaddingY = 200;
		Int32 chartW = 320;
		Int32 chartH = 200;
		Int32 chartXCount = 0;
		Int32 chartYCount = 1;
		Int32 marginTop = 0;
		Int32 marginLeft = 0;
		Int32 numCharts = 0;
		chartXCount = 0;
		chartYCount = 0;
		//foreach (var question in results.questions.Where(q => q.section_guid == section.Key))
		for (var i = 0; i < 10; i++)
		{
			marginLeft = (chartW + chartPaddingX)*chartXCount;
			// SET CHART PLACEMENT
			if (numCharts == 0)
			{
				marginTop = 50;
			}
			else if ((numCharts <= 3) && (numCharts != 0))
			{
				marginTop = 50;
			}
			else if (numCharts > 3)
			{
				marginTop = ((chartH + chartPaddingY)*chartYCount) + 50;
			}
			else
			{
				marginTop = (chartH + chartPaddingY)*chartYCount;
			}
			if (chartXCount >= 3)
			{
				//chart.SetPosition(marginTop, 50);
				Console.WriteLine("{{i: {0}, numCharts: {1}, left: {2}, top: {3}}}", i, numCharts, 50, marginTop); //Console.Writeline will simulate chart placement
				chartYCount++;
				chartXCount = 0;
			}
			else
			{
				//chart.SetPosition(marginTop, marginLeft + 50);
				Console.WriteLine("{{i: {0}, numCharts: {1}, left: {2}, top: {3}}}", i, numCharts, marginLeft + 50, marginTop); //Console.Writeline will simulate chart placement
			}
			chartXCount++;
			numCharts++;
		}
	}
