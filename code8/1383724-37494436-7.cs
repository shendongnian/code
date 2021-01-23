    //Fine in mono, not so much in Rosyln
    using System;
    
    public static class Program
    {
    	public static void Main() { Foo(Bar); }  // Outputs Func<string>
    
    	public static string Bar(string s1, string s2, string s3) { return "Fail"; }
    	public static string Bar(string s1, string s2) { return "Fail"; }
    	public static string Bar(string s1) { return "Fail"; }
    	public static string Bar() { return "Pass"; }
    
        // untick for compile failure
    	// public static void Foo(Func<string,string,string,string> input) { Console.WriteLine("<string,string,string,string>"); }
    	public static void Foo(Func<string> input) { Console.WriteLine("Func<string>"); }
    	public static void Foo(Func<int> input) { Console.WriteLine("Func<int>"); }
    	public static void Foo(Func<decimal> input) { Console.WriteLine("Func<decimal>"); }
    	public static void Foo(Func<char> input) {Console.WriteLine("Func<char>");}
    }
