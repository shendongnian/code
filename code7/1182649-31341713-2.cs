    private object ProcessData(string quality, string cars, string year)
        {
            var data = _repository.GetChartData(quality, cars, year);
            return new {
                categories = data.Select(d => d.Id).ToArray(),
                series = new[] { new { name = "Number of colors", data = data.Select(d => d.CumulativePercentage).ToArray() }}
            };
        }
