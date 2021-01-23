    using System;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main()
            {
                SimulateTenButtonClicks();
                Console.ReadKey();
            }
    
            private static async void SimulateTenButtonClicks()
            {
                var foo = new Foo();
                for (var i = 0; i < 10; i++)
                {
                    var result = foo.DoStuff(i);
                    Console.WriteLine(await result);
                }
            }
    
            public class Foo
            {
                public async Task<string> DoStuff(int i)
                {
                    await Task.Delay(500); // simulate load
                    return await Task.Run(() =>
                    {
                        return String.Format("I have been hit {0} times", i);
                    });
                }
            }
        }
    }
