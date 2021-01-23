    static void Main(string[] args)
    {
        Program myProgram = new Program();
		
		// This is your missing initialization
		myProgram.Blatherskite = new foo[2] {
			  new foo{CustomProperty1 = new bar[2]{new bar{CustomProperty2 = 1},new bar{CustomProperty2 = 2}}}
			, new foo{CustomProperty1 = new bar[2]{new bar{CustomProperty2 = 3},new bar{CustomProperty2 = 4}}}};
			
        myProgram.Blatherskite[0].CustomProperty1[0].CustomProperty2 = 999999999;
        myProgram.Blatherskite[1].CustomProperty1[0].CustomProperty2 = 999999999;
        foreach (var item in myProgram.Blatherskite)
        {
            Console.WriteLine(item.CustomProperty1[0].CustomProperty2);
        }
    }
