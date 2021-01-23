    var input = Console.Readline();
    Enrollment enrollment = null;
    try
    {
        enrollment = input.ParseEnrollment();
    }
    catch(Exception ex)//Whatever exception type you throw
    {
        //Error message or repeat showing the correct format.
    }
   
