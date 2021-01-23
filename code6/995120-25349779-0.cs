    private static void StartScraping(int id, IEnumerable<Uri> urls)
    {
        // Construct browser here
        foreach (Uri url in urls)
        {
            // Use browser to process url here
            Console.WriteLine("Browser {0} is processing url {1}", id, url);
        }
    }
