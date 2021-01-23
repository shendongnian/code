    private IQueryable SearchFilter(string param,string q,string filter,string value,string sort,string dir)
        {
            var emailMessage = db.EmailAflAwmMessage
                                .Where(ExpressionBuilder.BuildFilterPredicate<EmailMessage>(q))
                                .OrderBy(ExpressionBuilder.Selector<EmailMessage>(sort))
                                .Select(m=> new{m.subject,m.msg_date});        
        return emailmessage;
        }
