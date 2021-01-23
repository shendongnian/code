    For example, `LogViewModel` might look like this:
        public class LogViewModel
        {
            public int Id { get; set; }
            
            public int User_Id { get; set; }
            
            public DateTime Date { get; set; }
            
            public string Action { get; set; }
            
            public bool State { get; set; }
            
            public string Message { get; set; }
        }
    You'd then tweak your code to serialize a bunch of `LogViewModel`s instead:
        IEnumerable<LogViewModel> viewModels =
            _logList.Select(l => new LogViewModel
            {
                Id = l.Id,
                User_Id = l.User_Id
                /* etc. */
            });        
        String json = JsonConvert.SerializeObject(viewModels);
    The above mapping code can become tedious--that's where a tool like [AutoMapper](http://www.automapper.org) comes in.
    You could also just project an anonymous type containing the properties you care about with similar effect, however I find managing ViewModels to be much easier.
