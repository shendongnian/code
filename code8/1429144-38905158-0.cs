            using (var context = new UserDbContext())
            {
                context.Users.Attach(user);
                context.Entry(user).Collection(p => p.Purchases)
                .Query()
                .Where(whereClause ?? p => true)
                .Load();
                if (Equals(user.Purchases, null))
                    return new List<Purchases>();
            }
