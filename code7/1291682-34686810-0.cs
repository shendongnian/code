        public void EnableDebugging()
        {
            Database.Log = s =>
                           {
                               Console.Write(s);//windows apps
                               Debug.Write(s);//website apps
                           };
        }
