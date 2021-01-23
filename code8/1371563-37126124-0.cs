    static void Main(string[] args)
    {
    	Console.WriteLine("Busca els nombres amics entre 0 i 10000");
    	var list = new List<int>();
    	int numero, suma1, suma2;
    
    	for (numero = 1; numero < 10000; numero++)
    	{
    		suma1 = SumaDivisors(numero);
    		suma2 = SumaDivisors(suma1);
    
    		if (suma1 != numero && suma2 == numero && !list.Contains(suma1) && !list.Contains(suma2))
    		{
    			list.Add(suma1);
    			list.Add(suma2);
    
    			Console.WriteLine("Els nombre {0} i {1} són nombres amics", suma1, suma2);
    		}
    	}
    	
    	Console.ReadKey();
    }
