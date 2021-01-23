    public virtual MvcMailMessage OrderConfirmation()
        {
            return Populate(x =>
            {
                x.Subject = "Beställningsbekräftelse";
                x.From = new MailAddress("test@test.com", "test.com");
                x.ViewName = "OrderConfirmation";
                x.To.Add(order.Email);
                x.BodyEncoding = Encoding.UTF8;
                x.SubjectEncoding = Encoding.UTF8;
            });
        }
