        /// <summary>
        /// Get the nearest date from a range of dates.
        /// </summary>
        /// <param name="dateTime">The target date.</param>
        /// <param name="dateTimes">The range of dates to find the nearest date from.</param>
        /// <returns>The nearest date to the given target date.</returns>
        static DateTime GetNearestDate(DateTime dateTime, params DateTime[] dateTimes)
        {
            return dateTime.Add(dateTimes.Min(d => (d - dateTime).Duration()));
        }
