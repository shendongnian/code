            IQueryable<User> allBooleansTrue = new List<User>().AsQueryable();
            for (int i = 1; i <= numBools; i++)
            {
                int copy = i; //workaround to prevent closures using reference
                var q = context.UserBooleanAttributes.Where(y => y.UserAttributeID == copy && y.Value)
                    .Select(a => a.User);
                if (i == 1)
                    allBooleansTrue = q;
                else
                    allBooleansTrue = allBooleansTrue.Intersect(q);
