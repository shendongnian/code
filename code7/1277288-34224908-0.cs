    for (var i = 0; i < pa.Length; i+=2)
    {
        payment.Pay = Convert.ToDecimal(pa[i]);                 
        payment.PayCatId = Convert.ToInt32(pa[i+1]);
        payment.PayDate = DateTime.Now;
        db.Payments.Add(payment);
        db.SaveChanges();
     }
