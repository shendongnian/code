    ArrayList myArray = new ArrayList();
    int num1 = 0;
    int sum = 0;
    while (true)
    {
        num1 = int.Parse(Console.ReadLine());
        if (num1 == 999) break;
        myArray.Add(num1);
    }
    //OR simply sum = myArray.Cast<int>().Sum();
    foreach (int i in myArray)
    {
        sum = sum + i;
    }
    Console.WriteLine(String.Join(",",myArray.Cast<int>()));
    Console.WriteLine(sum);
