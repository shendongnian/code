    public static List<TPPROperatorDetails> GetOperators()
    {
        return DataHelper.DbTPPRTracer.TPPROperators.Select(
            op => new TPPROperatorDetails{
                Id = op.Id,
                FullName = op.Name, 
                UserName = op.UserName, 
                Designation = op.Position, 
                OperatorTypes = ParseOperatorType(op.UserType),
                SignatureImage = op.SignatureImage 
            })
            .Where(details => details.OperatorTypes == "Inactive")
            .ToList();
    }
