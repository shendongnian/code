    public async Task<ActionResult> Index()
    {
        List<Speaker> speakersAll1 = await _context.Speakers
                                                    .Include(a => a.Sessions.Select(b => b.Tenant))
                                                    .ToListAsync();
        foreach (var speaker in speakersAll1)
        {
            speaker.ImageUrl = "#";
        }
        byte[] objectDataAsStream;
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        using (MemoryStream memoryStream = new MemoryStream())
        {
            binaryFormatter.Serialize(memoryStream, speakersAll1);
            objectDataAsStream = memoryStream.ToArray();
        }
        return View("Index", "_Layout", objectDataAsStream.Length);
    }
