    public YourAuthService : IYourAuthService
    {
        public bool IsSerialValidForUser(string userName, string serial)
        {
            using(var context = new YourEntityFrameworkDbContext())
            {
                return context.Users.Any(u => u.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase) && u.Serial.Equals(serial, StringComparison.OrdinalIgnoreCase));
            }
        }
    }
