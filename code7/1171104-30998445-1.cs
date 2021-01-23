    var timeSlotInfoList = new List<TimeSlotInfo>();
    var jsonVal = System.IO.File.ReadAllText(@"C:\test.json"); // Somehow get JSON string into jsonVal. Not neccessarily from file.
    var obj = JsonConvert.DeserializeObject(jsonVal) as JObject;
    if (obj != null)
    {
        var jobj = obj.AsQueryable();
        foreach (JProperty item in jobj)
        {
            try
            {
                var dayOfMonth = Convert.ToInt32(item.Name);
                var timeSlotInfo = new TimeSlotInfo
                {
                    DayOfMonth = dayOfMonth
                };
                timeSlotInfoList.Add(timeSlotInfo);
                var timeSlots = item.Value.ToList();
                foreach (var timeSlotPair in timeSlots)
                {
                    var timeSlotPairList = timeSlotPair.ToList();
                    if (timeSlotPairList.Count != 2)
                        continue;
                    var slotItemStart = TimeSlotItem.CreateFromJTokenList(timeSlotPairList[0].ToList());
                    var slotItemEnd = TimeSlotItem.CreateFromJTokenList(timeSlotPairList[0].ToList());
                    if (slotItemStart != null && slotItemEnd != null)
                    {
                        timeSlotInfo.TimeSlots.Add(new TimeSlotRange
                        {
                            Start = slotItemStart,
                            End = slotItemEnd,
                        });
                    }
                }
            }
            catch (Exception)
            {
            }
        }
    }
