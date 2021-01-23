    using System;
    using System.Data.Entity;
    public static class DbFunctions
    {
        [DbFunction("Model.Store", "CONCAT2")]
        public static string Concat(string arg1, string arg2)
        {
            return String.Concat(arg1, arg2);
        }
    }
