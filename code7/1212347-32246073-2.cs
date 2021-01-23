    public static List<TPPROperatorDetails> GetOperators()
    {
        return DataHelper.DbTPPRTracer.TPPROperators
            .Where(op => ParseOperatorType(op.UserType) == "Inactive")
            .Select(
              op => new TPPROperatorDetails{
                Id = op.Id,
                FullName = op.Name, 
                UserName = op.UserName, 
                Designation = op.Position, 
                OperatorTypes = ParseOperatorType(op.UserType),
                SignatureImage = op.SignatureImage 
            })
            .ToList();
    }
