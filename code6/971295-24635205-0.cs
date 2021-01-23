    recordsEpP.Where(row=> !string.IsNullOrEmpty(row.Column20) &&                 
                           !string.IsNullOrEmpty(row.Column14) &&
                            string.IsNullOrEmpty(row.Column8)
             ).Select(row => new ReportDto{
                Status = "P",
                ContractNumber = row.ContractNumber,
                Count = 1
             }).ToList();
