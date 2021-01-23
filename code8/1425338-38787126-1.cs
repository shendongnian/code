    Boolean wrongInput=true;
    string read;
    int a;int b;
    while(wrongInput)
      {
        Console.WriteLine("enter a");
        read = Console.ReadLine(); 
        bool isNumeric = int.TryParse(read, out a);
        if(isNumeric){wrongInput=false;}
      }
    wronginput=while(wrongInput)
      {
        Console.WriteLine("enter b");
        read = Console.ReadLine();
        bool isNumeric = int.TryParse(read, out b);
        if(isNumeric){wrongInput=false;}
      }
