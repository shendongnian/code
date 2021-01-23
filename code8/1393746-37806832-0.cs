    public static void displayAnimal<T>(T mammal)
    {
        TargetType targetMammal = T as TargetType;
    
        if(targetMammal != null)
        {
            // the target type should have the function .GetDetails();
            targetMammal.GetDetails();
        }
    }
