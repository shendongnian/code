    public IQueryable<Car> GetTopCars(int count)
    {
        return (from c in context.Car
                let userVotes=car.UserVote.Where(uv=>!uv.User.IgnoreUser).Count()
                where userVotes > 0
                orderby userVotes
                select c)
               .Take(count);
    }
