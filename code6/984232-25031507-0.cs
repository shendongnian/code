        // checking if the person is born or not
        // if not: check if the person's age is possible or not
        if (AgeUtilities.IsPersonBorn(person.BirthDate) == false)
        {
            Console.WriteLine("Error....The user is not yet born.");
        }
        else if (AgeUtilities.IsPersonLongAgePossible(age, EXPECTEDAGELIMIT) == false)
        {
            Console.WriteLine("This age is not possible in Today's world.");
        }
