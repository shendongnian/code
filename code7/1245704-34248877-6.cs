        class Program
        {
            static void Main(string[] args)
            {
                var program = new Program();
                program.Run();
                Console.ReadKey();
            }
    
            async void Run()
            {
                // Example 1
                Console.WriteLine("#1: Upload invoice synchronously");
                var receipt = UploadInvoice("1");
                Console.WriteLine("Upload #1 Completed!");
                Console.WriteLine();
    
                // Example 2
                Console.WriteLine("#2: Upload invoice asynchronously, do stuff while you wait");
                var upload = UploadInvoiceAsync("2");
                while (!upload.IsCompleted)
                {
                    // Do stuff while you wait
                    Console.WriteLine("...waiting");
                    Thread.Sleep(900);
                }
                Console.WriteLine("Upload #2 Completed!");
                Console.WriteLine();
    
                // Example 3
                Console.WriteLine("#3: Wait on async upload");
                await UploadInvoiceAsync("3");
                Console.WriteLine("Upload #3 Completed!");
                Console.WriteLine();
    
                // Example 4
                var upload4 = UploadInvoiceAsync("4").ContinueWith<string>(AfterUploadInvoice);
            }
    
            string AfterUploadInvoice(Task<string> input)
            {
                Console.WriteLine(string.Format("Invoice receipt {0} handled.", input.Result));
                return input.Result;
            }
    
            string UploadInvoice(string id)
            {
                Console.WriteLine(string.Format("Uploading invoice {0}...", id));
                Thread.Sleep(2000);
                Console.WriteLine(string.Format("Invoice {0} Uploaded!", id));
                return string.Format("<{0}:RECEIPT>", id); ;
            }
    
            Task<string> UploadInvoiceAsync(string id)
            {
                return Task.Run(() => UploadInvoice(id));
            }
        }
    
    
