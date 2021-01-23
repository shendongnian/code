    public class FindUsersBySearchTextQuery : IQuery<Task<User[]>>
    {
    }
    public class FindUsersBySearchTextQueryHandler
        : IQueryHandler<FindUsersBySearchTextQuery, Task<User[]>>
    {
        public async Task<User[]> Handle(FindUsersBySearchTextQuery query)
        {
            // ...
        }
    }
