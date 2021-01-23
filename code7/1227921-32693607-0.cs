	var flags = PublishRequestStatus.Approved | PublishRequestStatus.Denied;
	var otherFlags = PublishRequestStatus.Approved | 
					 PublishRequestStatus.Denied | 
					 PublishRequestStatus.MaybeApproved;
	
	Console.WriteLine(otherFlags.HasFlags(flags)); // Yields true.
