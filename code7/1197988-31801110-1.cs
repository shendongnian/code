    string correctpassword = "michael";
    bool validpassword = false;
    do
    {
        Console.WriteLine("Please Enter your Password: ");
        var userinputpassword = Console.ReadLine();
        if (userinputpassword == correctpassword)
            validpassword = true;
        else
            Console.WriteLine("Incorrect Password.");
    } while (!validpassword);
    Console.WriteLine("Login Successful, Your password is: " + correctpassword );
