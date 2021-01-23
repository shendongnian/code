    public int CalculateEmpSal(int salary)
    {      
        var basic = salary * (0.40);
        return basic * (0.50); // this was HRA once..
    }
