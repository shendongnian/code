    using System; 
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                var magic = new Magic();
                var sum = magic.MagicAdd(2).MagicAdd(20).MagicAdd(50).MagicAdd(20).Result;
                Console.WriteLine(sum);
                Console.ReadKey();
            }
    
        }
    
        public class Magic
        {
            public int Result { get; set; }
    
            //method chaining
            public Magic MagicAdd(int num)
            {
                this.Sum(num);
                return this;
            }
    
            public int Sum(int x)
            {
                this.Result = this.Result + x;
                return this.Result;
    
            }
        }
    }
