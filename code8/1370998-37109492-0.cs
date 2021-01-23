        return igrndtlreturnRepository.GetList (x=> x.GRNNo == "GRN00022"  && x.ProductCode == "D/F/HL/DM/0003/C/002")
            .Select(y => new GRNDtlReturnModel
            {
                GRNNo = y.GRNNo,
                totalQuantity = context.GRNDtlReturns..Where(t=> t.GRNNo==y.GRNNo).Sum(p => p.ReturnQuantity)
            }).ToList();
    } 
