    DateTime dtFrom = DateTime.Today.AddDays(-3);
    DateTime dtTo = DateTime.Today;
    var query = from t in context.TRANSACTIONS
                .Where(tr=>tr.TXN_DATE>=dtFrom && tr.TXN_DATE<=dtTo)
                join s in context.SENDERS on t.TXN_SENDER_ID equals s.SEN_ID
                group new { t, s } by new { t.TXN_SENDER_ID, s.SEN_FIRSTNAME, s.SEN_LASTNAME, t.TXN_AMOUNT } into gr
                where (gr.Sum(x => x.t.TXN_AMOUNT) >= 2000)
                select new
                {
                    gr.Key.TXN_SENDER_ID, 
                    gr.Key.SEN_FIRSTNAME,
                    gr.Key.SEN_LASTNAME,
                    gr.Sum(a=>a.TXN_AMOUNT)
                };
