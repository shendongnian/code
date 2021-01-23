    public static class CustomCollectionExtension
    {
        public static bool AddEvent(this IList myList, EventHandler e)
        {
            // Do Some Stuff
            return true;
        }
        public static bool AddEvent(this ICollection myCollection, EventHandler e)
        {
            // Do Some Stuff
            return true;
        }
        // And so on...
    }
