    IEnumerable<SalaryFitmentInfoMonth> salaries;
    if(salaryFitmentDictionary.TryGetValue(1, out salaries))
    {
        SalaryFitmentInfoMonth salary = salaries.FirstOrDefault(s => s.EDId == 45);
        if(salary != null) 
        {
            // do something ...
        }
    }
