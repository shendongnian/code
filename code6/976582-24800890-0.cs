        public static PresenceEntities GetEFContext()
        {
            var edmConnectionString = [connection string here]
            return new PresenceEntities(edmConnectionString); //THIS LINE !!
        }
