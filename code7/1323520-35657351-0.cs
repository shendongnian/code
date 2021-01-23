    do 
    {
       Console.Write("Enter letter grade for class #{0} \n(use A, B, C, or D. Type 0 after all classes entered.): ", counter += 1);
                    char userInput = char.Parse(Console.ReadLine());
        
                    if (userInput == '0')
                    {
                        break;
                    }
        
                    else 
                    {
                        grade = userInput;
                        Console.Write("Enter your credit hours: ");
                        credit = int.Parse(Console.ReadLine());
                        bool throwErrorMsg = false;
                        switch (grade)
                        {
                            case 'A': gradePoints = 4;
                                break;
                            case 'B': gradePoints = 3;
                                break;
                            case 'C': gradePoints = 2;
                                break;
                            case 'D': gradePoints = 1;
                                break;
                            default: throwErrorMsg = true;
                                break;
                        }
                        if (throwErrorMsg)
                        {
                            Console.Write("Error...");
                            break;
                        }
                        totalGradePoints = totalGradePoints + (credit * gradePoints);
                        totalCreditHours = totalCreditHours + credit;
        
                    } 
        
                } while (grade != 0);
