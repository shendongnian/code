    using (StreamWriter sw = new StreamWriter(...))
    {
        sw.WriteLine("your content");
        // A bunch of writes
        // Commit everything we've written so far to disc
        // ONLY do this if you could stop writing at this point and have the file be in a valid state.
        sw.Flush();
       sw.WriteLine("more content");
       // More writes
    } // Now the using calls Dispose(), which calls Flush() again
