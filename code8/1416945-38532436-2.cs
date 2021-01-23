    private static readonly TimeSpan HalfHour = TimeSpan.Parse("0:30");
	private static IEnumerable<Schedule> Group(IList<GalaxySector> all) {
		// Protect from division by zero
		if (all.Count == 0) {
			yield break;
		}
		// Find initial location
		var pos = 0;
		while (pos < all.Count) {
			var prior = (pos + all.Count - 1) % all.Count;
			if (all[prior].End+HalfHour >= all[pos].Begin) {
				pos++;
			} else {
				break;
			}
		}
        // Protect from wrap-around when all items belong to a single window
        pos = pos % all.Count;
		// Start grouping items together
		var stop = pos;
		do {
			var start = pos;
			var next = (pos+1) % all.Count;
			while (next != stop && all[pos].End+HalfHour >= all[next].Begin) {
				pos = next;
				next = (pos+1) % all.Count;
			}
			yield return new Schedule {Begin = all[start].Begin, End = all[pos].End};
			pos = next;
		} while (pos != stop);
	}
