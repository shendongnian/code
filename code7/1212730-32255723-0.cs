    public bool Equals(Employee x, Employee y)
    {
        return x.EmployeeName.Equals(y.EmployeeName);
    }
    public int GetHashCode(Employee x)
    {
        return x.EmployeeName.GetHashCode()
    }
}
