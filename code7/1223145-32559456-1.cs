    public static void Add(
        this Dictionary<Device, Response> dictionary,
        Device device)
    {
        dictionary.Add(device, new Response(device));
    }
