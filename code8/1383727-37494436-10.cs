    //Fine in Roslyn, not so much in Mono
    using System;
    public static class Program
    {
    	public static void Main() { Foo(Bar); } // Outputs Func
    
    	public static string Bar() { return string.Empty; }
    	public static void Bar(string s1, string s2, string s3) { }
    	public static void Bar(string s1, string s2) {}
    	public static void Bar(string s1) { }
    
    	//untick for compile failure
    	//public static void Foo(Func<int> input) { }
    	public static void Foo(Action<string, string, string> input) { }
    	public static void Foo(Action<string, string> input) { }
    	public static void Foo(Action<string> input) { }
    	public static void Foo(Func<string> input) { Console.WriteLine("Func"); }
    }
