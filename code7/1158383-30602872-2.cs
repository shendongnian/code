        private void DoSomething(int thingId, string value)
        {
            try
            {
                ...
            }
            catch (Exception e)
            {
                throw new Exception("Failed to Do Something with arguments " +
                    new {thingId, value},
                    e); // remember to include the original exception as an inner exception
            }
        }
