    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Rogue rogue = new Rogue();
                Save(rogue, "1234");
            }
            static void Save(Character c, string file)
            {
                if(c.GetType() == typeof(Knight))
                {
                }
                if (c.GetType() == typeof(Rogue))
                {
                }
                if (c.GetType() == typeof(Wizard))
                {
                }
            }
        }
        public class Character
        {
        }
        public class Knight : Character
        {
        }
        public class Rogue : Character
        {
        }
        public class Wizard : Character
        {
        }
    }
