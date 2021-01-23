    public struct EmployeeKey
    {
        public int k;
        public DateTime d;
    }
    if (new EmployeeKey{k = employeeNote.EMP_NUM, d = employeeNote.From_Date}
              .Equals(default(EmployeeKey))
    {
        context.Entry(employeeNote).State = EntityState.Added;
    }
