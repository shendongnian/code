	class MyItem
	{
		// ...
	}
	class TimeSlot
	{
		public readonly DateTime TimeStamp;
		public TimeSlot(DateTime timeStamp)
		{
			TimeStamp = timeStamp;
			// ...
		}
		public bool IsComplete = false;
		public void HandleItemReceived(MyItem item)
		{
			// ...
		}
		// Dedicated members
		public TimeSlot PrevPending, NextPending;
	}
	class Synhronizer
	{
		TimeSlot firstPending, lastPending;
		int pendingCount;
		const int _capacity = 500;
		//Let's assume that this method is not called concurrently, and only once per "MyItem"
		public void HandleItemReceived(DateTime timeStamp, MyItem item)
		{
			var slot = GetOrAdd(timeStamp);
			//Sometimes we don't receive all the items for one timestamps, which may leads to some ghost-incomplete TimeSlot
			if (pendingCount > _capacity)
			{
				// Remove the oldest, which in this case is the first
				var oldestSlot = firstPending;
				Remove(oldestSlot);
				//Additional work here to log/handle this case
			}
			slot.HandleItemReceived(item);
			if (slot.IsComplete)
			{
				PushTimeSlotSyncronized(slot);
				Remove(slot);
			}
		}
		TimeSlot GetOrAdd(DateTime timeStamp)
		{
			// Starting from the end, search for a first slot with slot.TimeStamp <= timeStamp
			var slot = lastPending;
			while (slot != null && slot.TimeStamp > timeStamp)
				slot = slot.PrevPending;
			if (slot != null && slot.TimeStamp == timeStamp) return slot;
			// Insert a new slot after the found one (if any).
			var after = slot;
			slot = new TimeSlot(timeStamp);
			if (after != null)
			{
				slot.PrevPending = after;
				slot.NextPending = after.NextPending;
				after.NextPending = slot;
				if (slot.NextPending == null) lastPending = slot;
			}
			else
			{
				if (firstPending == null)
					firstPending = lastPending = slot;
				else
				{
					slot.NextPending = firstPending;
					firstPending.PrevPending = slot;
					firstPending = slot;
				}
			}
			pendingCount++;
			return slot;
		}
		void Remove(TimeSlot slot)
		{
			if (slot.NextPending != null)
				slot.NextPending.PrevPending = slot.PrevPending;
			else
				lastPending = slot.PrevPending;
			if (slot.PrevPending != null)
				slot.PrevPending.NextPending = slot.NextPending;
			else
				firstPending = slot;
			slot.PrevPending = slot.NextPending = null;
			pendingCount--;
		}
		void PushTimeSlotSyncronized(TimeSlot slot)
		{
			// ...
		}
	}
