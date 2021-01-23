    customers
    .OrderBy(x => x.CustomerId)
    .Select(c => {
        if (customer.CustomerId != customerId)
        {
            winningRate = Helper.Utility.WinningRate(settledCustomers, customer.CustomerId).Status;
            numberOfBets = customers.Count(x => x.CustomerId == customer.CustomerId);
            numberOfWinnings = customers.Count(x => x.CustomerId == customer.CustomerId && x.Win > 0);
            averageBet = Helper.Utility.CustomerAverageBet(settledCustomers, customer.CustomerId);
        }
    
        var risky = Helper.Utility.CheckRiskyBet(winningRate, numberOfWinnings, numberOfBets, averageBet, customer.Stake, customer.Win);
    
        return new Customer
            {
                Status = risky.Status,
                Message = risky.Message,
                CustomerId = c.CustomerId
            };
    });
