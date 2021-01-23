    var sortedQuery2 = sortedQuery1
        .Orderby(itemSortedByDeparmentIdAndShiftDate =>
            // What value must be used to sort this item?
            // Answer: The minimum StartTime of all times in ShiftMissions
            // so for each item calculate the minimum Starttime:
            itemSortedByDepartmentIdAndShiftDate.ShiftMissions
                .Min(shiftMission => shiftMission.StartTime);
