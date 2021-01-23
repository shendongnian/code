    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApplication6
    {
        class Program
        {
            static void Main(string[] args)
            {
                Base good = new Good();
                Base bad = new Bad();
                good.Validate();
                bad.Validate(); // This blows up
                Console.ReadLine();
            }
        }
        public class Base
        {
            public virtual void Validate()
            {
                throw new NotImplementedException();
            }
        }
        public class Good : Base
        {
            public override void Validate()
            {
                Console.WriteLine("Looks good to me.");
            }
        }
        public class Bad : Base
        {
        }
    }
