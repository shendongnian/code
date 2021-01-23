    DateTime dPurchase, dPaid;
    int amount;
    double? discount = null;
    double totalAmount, days;
    S.Write("Purchase amount: ");
    amount = Convert.ToInt16(S.ReadLine());
    S.Write("Date Purchased: ");
    dPurchase = Convert.ToDateTime(S.ReadLine());
    S.Write("Date to be Paid: ");
    dPaid = Convert.ToDateTime(S.ReadLine());
    days = dPaid.Subtract(dPurchase).TotalDays;
    if (days <= 10) 
        discount = amount * 0.2;
    else if (days <= 25)
        discount = amount * 0.15;
    else if (days <= 35)
        discount = amount * 0.1;
    else if (days <= 45)
        discount = amount * 0.05;
    totalAmount = amount - discount.GetValueOrDefault();    
    if (discount.HasValue)
        S.Write("Discount: " + discount.Value + "\nTotal Amount: " + totalAmount);
    S.Write("Days: " + days + "\n");
    S.Write("First Term: " + dPurchase.Date.AddDays(1) + " to " + dPurchase.Date.AddDays(10) + "\n");
    S.Write("Second Term: " + dPurchase.Date.AddDays(11) + " to " + dPurchase.Date.AddDays(25) + "\n");
    S.Write("Third Term: " + dPurchase.Date.AddDays(26) + " to " + dPurchase.Date.AddDays(35) + "\n");
    S.Write("Fourth Term: " + dPurchase.Date.AddDays(36) + " to " + dPurchase.Date.AddDays(45) + "\n");
    S.Write("Fifth Term: " + dPurchase.Date.AddDays(46) + " to " + dPurchase.Date.AddDays(60) + "\n");
    S.ReadKey();
