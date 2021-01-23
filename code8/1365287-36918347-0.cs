        public enum Status
        {
            GoodStatus,
            BadStatus,
            Unknown
        }
    
        public class foo
        {
            public Status status;
        }
    
        public void Execute()
        {
            List<foo> list = new List<foo>
            {
                new foo
                {
                    status = Status.BadStatus
                },
                new foo
                {
                    status = Status.GoodStatus
                },
                new foo
                {
                    status = Status.GoodStatus
                },
                new foo
                {
                    status = Status.Unknown
                }
            };
    
    
            var descStatus = list.Select(GetStatus).ToList();
        }
    
        public Expression<Func<foo, object>> GetStatus(foo _foo)
        {
            return x => new
            {
                enumDesc = _foo.status == Status.GoodStatus
                    ? "Good!"
                    : _foo.status == Status.BadStatus
                        ? "Bad<angryface>"
                        : _foo.status == Status.Unknown ? "no clue" : ""
            };
        }
