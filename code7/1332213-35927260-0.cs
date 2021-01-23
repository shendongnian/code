        Console.Clear();
        string text1 = ("As you slither forward, you spot a rabbit close by. What will you do?\nA Leave it \nB Eat it!");
        for (int i = 0; i < text1.Length; i++)
        {
            Console.Write(text1 [i]);
            System.Threading.Thread.Sleep(75);
        }
        Console.ReadLine();
