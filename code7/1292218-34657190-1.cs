    public static bool AccountHasBonus(IEnumerable<Transaction> transactions,
                                       decimal startBallance, 
                                       decimal ballanceThreshold)
	{
		var thresholdReached = false;
		
		transactions.TakeWhile(_ => !thresholdReached)
                    .Aggregate(startBallance, 
							   (sum, transaction) => 
							   {
								   var sign = transaction.Type == TransactionType.D ? -1m : 1m;
								   sum += sign * transaction.Value;
								   if (sum >= ballanceThreshold)
									   thresholdReached = true;
								   return sum;
							   });
		
		return thresholdReached;
	}
