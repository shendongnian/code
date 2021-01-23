	Console.WriteLine(IsSubclassOfGeneric(typeof(A<>), typeof(A<>)));
	Console.WriteLine(IsSubclassOfGeneric(typeof(A<int>), typeof(A<>)));
	Console.WriteLine(IsSubclassOfGeneric(typeof(B1), typeof(A<>)));
	Console.WriteLine(IsSubclassOfGeneric(typeof(B2), typeof(A<>)));
	Console.WriteLine(IsSubclassOfGeneric(typeof(C), typeof(A<>)));
	Console.WriteLine(IsSubclassOfGeneric(typeof(D), typeof(A<>)));
	Console.WriteLine(IsSubclassOfGeneric(typeof(string), typeof(A<>))); // false
