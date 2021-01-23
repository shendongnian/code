    using System;
    using MathWorks.MATLAB.NET.Arrays;
    using MathWorks.MATLAB.NET.Utility;
    using myLib;
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("calling myFunction(varargin)...");
            CallMyFunction(1, 2.0f, 3.14, "str4");
        }
        static void CallMyFunction(params MWArray[] varargin)  // or object[]
        {
            myClass obj = new myClass();
            obj.myFunction(varargin);
        }
    }
