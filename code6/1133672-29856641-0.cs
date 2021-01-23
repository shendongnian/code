            static Expression<Func<Invoice, bool>> IsAllocatedExpr()
            {
                return i => i.TotalAmountDue == i.GetAllocationsTotal();
            }
            public static Func<Invoice, bool> IsAllocated = IsAllocatedExpr().Compile();
