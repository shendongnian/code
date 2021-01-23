    using System.Linq.Dynamic;
    // ....
    var predicateBuilder = new StringBuilder();
    
    for (var i = 0; i < keywords.Length; i++)
    {
        predicateBuilder.AppendFormat("empName.Contains(@{0}) 
                                        OR data.bank.bankCode.Contains(@{0})
                                        OR data.bank.bankName.Contains(@{0})
                                        OR ... and so on", i);
                                        
        if (i < keywords.Length - 1)
        {
            predicateBuilder.Append(" OR ");
        }
    }
    
    query = query.Where(predicateBuilder.ToString(), 
                        keywords.Cast<object>().ToArray());
    
    var result = (IEnumerable<YourClass>)query.ToList();
