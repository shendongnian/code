    public async Task ReviewPeerPaymentWorks() {
        using (var db = new AppContext()) {
            var user1 = db.FindUser("M1");
            var user2 = db.FindUser("M2");
            db.Reviews.Add(review);
            var payment = new Payment() {
                FromUserId = user1.UserId,
                ToUserId = user2.UserId,
                Review = new Review() {
                   FromUserId = user1.UserId,
                   ToUserId = user2.UserId
                }
            };
            db.Payments.Add(payment);
            db.SaveChanges();
            review = db.Reviews.First(s => s.ReviewId == review.ReviewId);
            payment = db.Payments.First(s => s.PaymentId == payment.PaymentId);
            Assert.AreEqual(review.PaymentId, payment.PaymentId); // fails - review.PaymentId is always null
            Assert.AreEqual(review.ReviewId, payment.ReviewId); // passes
            Assert.AreEqual(review.Payment.PaymentId, payment.Review.PaymentId); // fails - review.Payment is null, payment.Review.PaymentId is null
        }
    }
