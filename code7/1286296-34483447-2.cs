    public class FakeGuest : ParseObject
    {
        private static readonly Random Rand = new Random();
        public static ParseObject Create(int id)
        {
            var guest = Create("Guest");
            guest.Add("driver", Rand.NextDouble() <= 0.5);
            var user = Create("User");
            user.Add("id", id);
            guest.Add("user", user);
            return guest;
        }
    }
