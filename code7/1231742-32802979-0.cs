	Array.Sort(numeros);
	Console.WriteLine("Numeros ingresados de forma ascendente  :");
	for (int i = 0; i < 5; i++)
	{
		Console.Write("{0} ", numeros[i]);
	}
	Array.Reverse(numeros); 
	Console.WriteLine(Environment.NewLine + "Numeros ordenados de forma descendente :");
	for (int i = 0; i < 5; i++)
	{
		Console.Write("{0} ", numeros[i]);
	}
