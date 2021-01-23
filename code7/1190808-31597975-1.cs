    var final = q.Join(                               // Join instead of GroupJoin
            rewards.Where(r => r.RewardCount < 5),    // filter out rewards >= 5
            i => i.UserCustomer.User_Customer_ID, 
            j => j.CustomerID, 
           (i, j) => new { Customer = i, Reward = j })
        .Select(i => new { 
            Reward = i.Reward,                            // 'Count' is a bad name
                                                          // it is still the reward object
            id = i.Customer.UserCustomer.User_Customer_ID
        })
        .ToList();
