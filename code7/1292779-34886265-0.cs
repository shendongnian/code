        public static IQueryable<COLOURS> DefaultColours()
        {
            const int COUNT = 500;
            List<COLOURS> x = new List<COLOURS>();
            var startDate = DateTime.Today.AddDays(-1 * (int)(COUNT / 2));
            // add 500 date values, and use the date and any random bool value
            for (int i = 0; i < COUNT; i++)
                x.Add(new COLOURS() { add_date = startDate.AddDays(i), is_new = i % 3 == 0 });
            return x.AsQueryable();
        }
