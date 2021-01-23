    public class Program
        {
            static void Main()
            {
                // all walkins
                var walkins =
                    // all persons through a door each second
                    Observable.Interval(TimeSpan.FromSeconds(1), Scheduler.CurrentThread)
                    // if has phone (is even) then true, if not false
                    .Select(i => (i % 2 == 0));
    
                var phoneWalkins = // substream of phoneWalkins (if you want it separate)
                    walkins
                    .Where(i => (i == true))
                    .Select(i => i);
    
                var nonPhoneWalkins = // substream of nonPhoneWalkins (if want it separate)
                    walkins
                    .Where(i => (i == false))
                    .Select(i => i);
    
                //walkins.Subscribe(Console.WriteLine); // output all
                phoneWalkins.Subscribe(Console.WriteLine); // output phone
                //nonPhoneWalkins.Subscribe(Console.WriteLine); // output nonPhone
            }
        }
