    public IQueryable<Car> GetTopCars(int count)
    {
        return (from c in context.Car
                join uv in context.UserVotes on c.Id equals uv.CarId
                join u in context.UserVotes on uv.UserId equals u.Id into users
                let userVotes= users.Where(u=>!u.IgnoreUser).Count()
                where userVotes > 0
                orderby userVotes
                select c
               )
               .Take(count);
    }
