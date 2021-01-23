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
		const int _capacity = 500;
		Dictionary<DateTime, TimeSlot> pendingSlotMap = new Dictionary<DateTime, TimeSlot>(_capacity + 1);
		TimeSlot firstPending, lastPending;
		//Let's assume that this method is not called concurrently, and only once per "MyItem"
		public void HandleItemReceived(DateTime timeStamp, MyItem item)
		{
			TimeSlot slot;
			if (!pendingSlotMap.TryGetValue(timeStamp, out slot))
			{
				slot = new TimeSlot(timeStamp);
				Add(slot);
				//Sometimes we don't receive all the items for one timestamps, which may leads to some ghost-incomplete TimeSlot
				if (pendingSlotMap.Count > _capacity)
				{
					// Remove the oldest, which in this case is the first
					var oldestSlot = firstPending;
					Remove(oldestSlot);
					//Additional work here to log/handle this case
				}
			}
			slot.HandleItemReceived(item);
			if (slot.IsComplete)
			{
				PushTimeSlotSyncronized(slot);
				Remove(slot);
			}
		}
		void Add(TimeSlot slot)
		{
			pendingSlotMap.Add(slot.TimeStamp, slot);
			// Starting from the end, search for a first slot having TimeStamp < slot.TimeStamp
			// If the TimeStamps almost come in order, this is O(1) op.
			var after = lastPending;
			while (after != null && after.TimeStamp > slot.TimeStamp)
				after = after.PrevPending;
			// Insert the new slot after the found one (if any).
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
		}
		void Remove(TimeSlot slot)
		{
			pendingSlotMap.Remove(slot.TimeStamp);
			if (slot.NextPending != null)
				slot.NextPending.PrevPending = slot.PrevPending;
			else
				lastPending = slot.PrevPending;
			if (slot.PrevPending != null)
				slot.PrevPending.NextPending = slot.NextPending;
			else
				firstPending = slot;
			slot.PrevPending = slot.NextPending = null;
		}
		void PushTimeSlotSyncronized(TimeSlot slot)
		{
			// ...
		}
	}
