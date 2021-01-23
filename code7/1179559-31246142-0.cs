    var columns = data.GroupBy(d => d.Service, (key, items) => key).ToList();
    var groupedData = data.GroupBy(
      d => d.Vehicle,
      (key, items) => new {
        Key = key,
        Values = items.ToDictionary(item => item.Service, item => item.Value)
      }
    );
