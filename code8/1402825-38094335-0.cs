    var summary = session.QueryOver<FinancialTransactionTO>().Select(
                Projections.Group<FinancialTransactionTO>(t => t.Company.Id),
                Projections.Sum<FinancialTransactionTO>(t => t.Total),
                Projections.Sum(
                Projections.Conditional(
                Restrictions.Where<FinancialTransactionTO>(f => f.Type.Id == 1),
                Projections.Property<FinancialTransactionTO>(f=>f.Total),
                Projections.Constant(0.0M, NHibernateUtil.Decimal)))).List<object>();
            return summary;
