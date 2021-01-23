    Dictionary<string, int> dic = new Dictionary<string, int>(); //note this dict type
    
    List<string> mylist = new List<string>();
    string[] str = new string[5];
    int counter = 0;
    for (int i = 0; i < 5; i++)
    {
        Console.Write("Type Number:");
        string test = Console.ReadLine();
        mylist.Add(test);
        counter++;
    }
    string key = string.Join("", mylist); //note this key combination
    //you will have key-value pair such as "12345"-5
    
    Console.WriteLine(string.Join(",", mylist)); //note, you will print as "1,2,3,4,5"
    dic.Add(key, counter);
