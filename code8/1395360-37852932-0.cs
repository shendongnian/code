        ServerDll.Server ob = new ServerDll.Server();
        for ( int i = 0 ; i<10; i++ )
        {
            string appendedString;
            lock(ob)
            {
                ob.GiveAppendedString("Hello");
            }
            Console.WriteLine(appendedString);
        }
