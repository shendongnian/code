    using System;
    using System.Net.Http;
    
    namespace Temp
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                Console.WriteLine("Enter to continue");
                Console.ReadLine();
                DoIt();
                Console.ReadLine();
            }
    
            private static async void DoIt()
            {
                using (var stringContent = new StringContent("{ \"firstName\": \"John\" }", System.Text.Encoding.UTF8, "application/json"))
                using (var client = new HttpClient())
                {
                    try
                    {
                        var response = await client.PostAsync("http://localhost:52042/api/values", stringContent);
                        var result = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(result);
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                        Console.ResetColor();
                    }
                }
            }
        }
    }
