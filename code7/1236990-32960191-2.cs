    public IHttpActionResult TimeDatawithUserandServer(string name, string group)
    {
        List<Model> res = new List<Model>();
        var groupedData = GetGroupedList(group, name);
        res.AddRange(groupedData.Select(item => new Model()
            {
                Count = item.Count(),
                Date = item.Key.EventDate.ToString("yyyy-MM-dd HH:mm:ss"),
                Name = item.Key.Server
            }));
        return Ok(res);
    }
    private static IEnumerable<GroupedDataType> GetGroupedList(string group, string name)
    {
        var filteredList = db.Overalldatas.Where(dbData => Filter(dbData, group, name));
        return filteredList.GroupBy(x => new {x.EventDate, x.User}).ToList();;
    }
    private static readonly Func<ODType, string, string, bool> Filter = (ode, group, name) =>
            {
                var objType = overallDataElement.GetType();
                var field = objType.GetMember(group)[0];
                return (field != null)
                    && ((FieldInfo) field).GetValue(ode).ToString().Equals(name);
            };
