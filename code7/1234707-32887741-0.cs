    Dictionary<int,Patient> patients = new Dictionary<int,Patient>();
    while (true)
    {
        Console.Write("\nEnter Patient Account Number: ");
        int number = Convert.ToInt32(Console.ReadLine());
        if (patients.ContainsKey(number))
        {
            Console.Write("\nSorry, Patient Account Number {0} is a duplicate.", number);
            Console.Write("\nPlease re-enter the Patient Account Number: ");
            continue;
        }
        Console.Write("***Patient Account Number unique and accepted***\n");
        Console.Write("Enter the Patient Name: ");
        string name = Console.ReadLine();
        Console.Write("Enter the Patient Age: ");
        int age = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter the total annual Patient amount due: ");
        double amountDue = Convert.ToDouble(Console.ReadLine());
        patients.Add(number, new Patient(number, name, age, amountDue));
    }
