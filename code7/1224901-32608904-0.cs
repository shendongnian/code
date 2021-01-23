    bool input_ok = false;
    int input;
    while (! input_ok)
    {     
         Console.Write("{0}. Age: ", a + 1);
         input_ok = int.TryParse(Console.ReadLine(), out input);
         if (input_ok)
            {
                stu.setstudentAge(input)
            }
    }
