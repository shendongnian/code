    using Newtonsoft.Json;
    [HttpPost]
    public void SaveCalendarData()
    {
        string json = Request.Form["dopbcp_schedule"];
        Dictionary<string, DayInfo> calendarData = JsonConvert.DeserializeObject<Dictionary<string, DayInfo>>(json);
        // Process dictionary...
    }
