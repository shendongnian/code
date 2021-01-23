            try
            {
                throw new NullReferenceException("No, Really");
            }
            catch(Exception ex) when (FilterExType(ex))
            {
                Console.WriteLine($"2: Caught 'any' exception: {ex}");
            }
        static bool FilterExType(Exception ex)
        {
            if (ex is NullReferenceException)
            {
                Environment.FailFast("BOOM from C#!", ex);
            }
            // always handle if we return
            return true;
        }
