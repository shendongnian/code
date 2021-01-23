    public async Task<IEnumerable<PaymentInfo>> LoadAllPaymentInfoAsync()
    {
        var payments = await SqliteService.Conn.Table<Payment>().ToListAsync();
        var payees = await SqliteService.Conn.Table<Payee>().ToListAsync();
        var query = from p1 in payments
            join p2 in payees on p1.PayeeId equals p2.Id
            select new PaymentInfo() {Payment = p1, Payee = p2};
        return query;
    }
