    List<newClass> items = new List<newClass>();
    newClass last = null;
    foreach (var item in acts) {
            // update the last element here:
            if (last != null)
                last.EndTime = item.ActivityTime;
            newClass si = new newClass
                        {
                            Name=item.Name,
                            AdditionalData=item.AdditionalData,
                            StartTime = item.ActivityTime ,
                            EndTime = null; // will be updated in the next loop
                        };
            last = si;
            items.Add(si);
    }
