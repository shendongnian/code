    int dollar = 100;
    decimal quarter = .25m;
    decimal dime = .10m;
    decimal pennie = .01m;
    Console.WriteLine("tell me how much money you have, make sure you include doolars and cents. ");
    string userMoney = Console.ReadLine();
    double userMoney1 = double.Parse(userMoney);
    Console.WriteLine("that equals, {0} ", userMoney);
    Console.ReadLine();
