    do{
    Console.SetCursorPosition(Console.WindowWidth/2-2,3);
    switch(fotograma++%4)
        {
                case 0 :
                    Console.Write("|");
                    break;
                case 1 :
                    Console.Write("/");
                    break;
                case 2 :
                    Console.Write("-");
                    break;
                case 3 :
                    Console.Write("\\");
                    break;      
            }
        System.Threading.Thread.Sleep(50);
    }while(!Console.KeyAvailable);
