        else {
            j = (end.Day - start.Day) + 1;
        }
    }
    else {
        if (start.Day == 1) {
            j = j + 30;
        }
        else {
            j = j + DateTime.DaysInMonth(start.Year, start.Month) - start.Day + 1;
        }
        if (end.Day == 30 || end.Day == 31) {
            j = j + 30;
        }
        else {
            j = j + end.Day;
        }
    }
    newDaysDiff = newDaysDiff + j;
    return newDaysDiff;
}
