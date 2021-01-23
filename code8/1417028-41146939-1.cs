        static void Main()
        {
            using (InviteesDbContext dbContext = new InviteesDbContext(false))
            {
                Console.WriteLine("Database in existence or created");
                Invitee invitee = dbContext.Invitees.Where(i => i.Id == 1).SingleOrDefault();
                if (invitee != null)
                {
                    Console.WriteLine("Invitee " + invitee.Id.ToString() + " found !!");
                }
                Console.ReadKey();
            }
        }
