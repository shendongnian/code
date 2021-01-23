    do
    {
        currentCount = 1;
        while (currentCount <= maxCount)
        {
            subject = ReadSubject();
            grade = ReadGrade();
            points = GetPointsFor(grade);
    
            if (IsValid(points)) //You currently have a bug here
            {
                StoreSubjectValues(currentCount, subject, grade, points);
                currentCount++;
            }
            else
            {
                PrintError(subject, grade);
            }
        }
        
        //This is what you want to add for the printout
        for (currentCount = 1; currentCount <= maxCount; currentCount++)
        {
            PrintSubjectValues(subjectValuesFor[currentCount]);
        }
        userWantsToContinue = AskUserToContinue();
    } while (userWantsToContinue);
