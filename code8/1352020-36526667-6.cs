    var model = new MonthPaymentsVM()
    {
        Date = date,
        Categories = categories.Select(x => x.CategoryName),
        Payments = new List<MemberPaymentVM>()
    };
    foreach(var group in data)
    {
        PaymentVM payment = new PaymentVM(categoryCount);
        payment.Name = group.First().Member.Name;
        foreach (var item in group)
        {
            int index = categoryIDs.IndexOf(item.Category.CategoryId);
            payment.Amounts[index] = item.Amount;
        }
        model.Payments.Add(payment);
    }
