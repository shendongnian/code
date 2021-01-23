    public void UpdateEmployee(Employee updatedEmployee)
    {
        if (this.No == updatedEmployee?.No)
        {
            this.FirstName = updatedEmployee.FirstName;
            this.LastName = updatedEmployee.LastName;
        }
        else
        {
            // throw
        }
    }
