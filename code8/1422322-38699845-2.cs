    public static double CalculateHours(this List<EmployeeStatusChange> changes)
        {
            changes = changes.OrderBy(x => x.DateTime).ToList();
            double hours = 0;
            var start = DateTime.MinValue;
            var lunch = DateTime.MinValue;
            var checkedOut = false;
            foreach (var change in changes)
            {
                // exclude anything before the first check in, or if we have already checked out
                if ((start == DateTime.MinValue && change.Status != Status.CheckIn) || checkedOut)
                {
                    continue;
                }
                // Set the start time
                if (start == DateTime.MinValue && change.Status == Status.CheckIn)
                {
                    start = change.DateTime;
                    continue;
                }
                switch (change.Status)
                {
                    case Status.CheckIn:
                        if (lunch == DateTime.MinValue)
                        {
                            continue;
                        }
                        start = change.DateTime;
                        continue;
                    case Status.Lunch:
                        lunch = change.DateTime;
                        hours += (change.DateTime - start).TotalHours;
                        break;
                    case Status.CheckOut:
                        checkedOut = true;
                        hours += (change.DateTime - start).TotalHours;
                        break;
                }
            }
            return hours;
        }
