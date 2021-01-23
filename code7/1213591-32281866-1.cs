    {
        //declare varibles
        double[] chevy = new double[8];
        double[] ford = new double[8];
        int x, y;
        double ctotal = 0, chevyaverage = 0;
        double ftotal = 0, fordaverage = 0;
        double cwin= 0, fwin = 0;
        //calculations
        //input
        for (x = 0; x < 8; x++)
        {
            Console.Write("Enter time for chevy car " + (x + 1) + ":");
            chevy[x] = double.Parse(Console.ReadLine());
        }
        for (y = 0; y < 8; y++)
        {
            Console.Write("Enter time for ford car " + (y + 1) + ":");
            ford[y] = double.Parse(Console.ReadLine());
        }
        int cn=0,fn=0; //count of chevy wins and ford wins
        for(int x=0,int y=0;x<8;x++,y++)
        {
          if (chevy[x] < ford[y])
          {
            cn++;//chevy wins soo increment this
            cwin = chevy[x] - ford[y];
            Console.WriteLine("Chevy won by: " + cwin);
          }
          else if (ford[y] < chevy[x])
          {
            fn++;// ford wins
            fwin = ford[y] - chevy[x];
            Console.WriteLine("Ford won by: " + fwin);
          }
          else
          {
            Console.WriteLine("Tie!");// In tie no one wins so need not include this.
          }
        //output
        for (x = 0; x < 8; x++)
        {
            ctotal = ctotal + chevy[x];
        }
        chevyaverage = ctotal / 8;
        for (y = 0; y < 8; y++)
        {
            ftotal = ftotal + ford[y];
        }
        fordaverage = ftotal / 8;
        if(cn>fn)//checking the number of wins for each team
        {
            Console.WriteLine("Chevy wins");
        }
        else
            Console.writeLine("Ford wins");
        Console.WriteLine("The average time in seconds for each chevy car is: " + chevyaverage);
        Console.WriteLine("The average time in seconds for each ford car is: " + fordaverage);
        Console.ReadLine();
     }
    }
