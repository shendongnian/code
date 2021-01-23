    public static bool sokning(int[] a, int b)
    {
        bool sant = false;
        Random rand = new Random();
        Stopwatch watchFindArray = new Stopwatch();
        Console.Write("Letar efter tal: ");
        watchFindArray.Start();
        int myint = 0;
        // Search only 100 numbers like you do in the linked list
        for (int iii = 0; iii < 100; iii++)
        {
            b = rand.Next();
            Console.Write("#");
            myint = Array.BinarySearch(a, b);
            if (myint < 0)
            {
                sant = false;
            }
            else
            {
                sant = true;
            }
        }
        watchFindArray.Stop();
        if (sant == true)
        {
            Console.WriteLine("\nFann alla element efter " + watchFindArray.Elapsed.TotalSeconds + " sekunder.");
            return true;
        }
        else
        {
            return false;
        }
    }
