    // File 1
    public static class Globals
    {
        public const string bobsName = "bob!";
    }
    // File 2
    using System;
    using static Globals;
    class BobFinder
    {
        void Run() => Console.WriteLine(bobsName);
    }
