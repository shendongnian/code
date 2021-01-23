    public static class ExtensionMethods {
        public static IQueryable<Invoice> Search(this IQueryable<Invoice> src, int merchant,
            long buyer, bool send, bool paid, bool firstReminder,
            bool secondReminder, bool invoiceClaim)
        {
            var predicate = PredicateBuilder.False<Invoice>();
            var sendValue = new InvoiceStatus();
            var paidValue = new InvoiceStatus();
            var firstRemind = new DateTime();
            var secondRemind = new DateTime();
            if (buyer <= 0)
            {
                return src.Where(predicate);
            }
            predicate=predicate.Or(i=>i.InstallationId == merchant && i.Buyer.Msisdn == buyer);
            if (send)
            {
                 predicate=predicate.Or(i=>i.Status == InvoiceStatus.Sent);
            }
            if (paid)
            {
                predicate=predicate.Or(i=>i.Status == InvoiceStatus.Paid);
            }
            if (firstReminder)
            {
                predicate=predicate.Or(i=>i.FirstReminderDate == DateTime.Today);
            }
            if (secondReminder)
            {
                predicate=predicate.Or(i=>i.SecondReminderDate == DateTime.Today);
            }
            return src.Where(predicate);
        }
    }
