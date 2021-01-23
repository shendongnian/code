    public int CalculateEmpSal(int empId,int salary)
    {      
        // local varibles
        int Basic; 
        int HRA;       
        // Calculate employee salary
        Basic = salry * (0.40);
        HRA = Basic * (0.50);
        return HRA;
    }
