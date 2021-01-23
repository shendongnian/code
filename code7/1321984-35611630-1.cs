    static PickUps FindClosestPickUp(List<PickUps> pickUpList, DateTime baseTime)
    {
    	PickUps closestPickUp = null;
    	TimeSpan closestDuration = default(TimeSpan);
    	foreach (var pickUp in pickUpList)
    	{
    		var duration = (pickUp.PickUpTime - baseTime).Duration();
    		if (closestPickUp == null || closestDuration > duration || (closestDuration == duration && closestPickUp.PickUpTime > pickUp.PickUpTime))
    		{
    			closestPickUp = pickUp;
    			closestDuration = duration;
    		}
    	}
    	return closestPickUp;
    }
