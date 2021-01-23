       static void Main(string[] args)
        {
            Console.WriteLine("Main started");
            ShowPatientVisitsVsDays();
            Console.ReadLine();
        }
       private static async void ShowPatientVisitsVsDays()
        {
            await ShowRequestsVsDaysAsync();
            Console.WriteLine("ShowPatientVisitsVsDays() method is going to SLEEP");
            Thread.Sleep(2000);
            Console.WriteLine("ShowPatientVisitsVsDays() method finished");
        }
       private static async Task ShowRequestsVsDaysAsync()
        {
            await Task.Run(() =>
            {
                Console.WriteLine("ASYNC ShowRequestsVsDaysAsync() is going to SLEEP.");
                Thread.Sleep(5000);
                Console.WriteLine("ASYNC ShowRequestsVsDaysAsync finished.");
            });
        }
     }
