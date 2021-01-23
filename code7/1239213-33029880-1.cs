    int injtaille =0; // default value here
    if (inj == "oui")
    {
        Console.WriteLine("Quel est la taille de l'injection? (30 - 50 - 60) ");
        injtaille = Convert.ToInt32(Console.ReadLine());
    }
    switch (client)
    {
        case 1:
           consprix = 25;
           imgradprix = 55;
           analyzeprix = 28;
           switch (injtaille)
           {
               case 30:
                  ....
           }
