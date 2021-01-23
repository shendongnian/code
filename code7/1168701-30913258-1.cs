    double GetNumberFromUser() {
        double Num = double.NaN;
        while(!double.tryParse(Console.ReadLine(), out Num) && !double.IsNaN(Num))
        {
            Console.Beep();
            Console.WriteLine("");
            Console.WriteLine("You have entered an invalid number!");
            Console.WriteLine("");
        }
        return Num;
    }
