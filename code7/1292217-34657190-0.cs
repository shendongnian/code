    public static bool IsAccountGood(IEnumerable<Transaction> transactions,
                                     decimal startBallance, 
                                     decimal ballanceThreshold)
	{
		var thresholdReached = false;
		
		transactions.TakeWhile(_ => !thresholdReached)
                    .Aggregate(startBallance, 
							   (sum, transaction) => 
							   {
								   var sign = transaction.Type == TransactionType.D ? -1m : 1m;
								   var newSum = sum + sign * transaction.Value;
								   if (newSum >= ballanceThreshold)
									   thresholdReached = true;
								   return newSum;
							   });
		
		return thresholdReached;
	}
