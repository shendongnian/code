    private static List<string> plants;
    public static void InitializeList()
    {
        plants = new List<string>();
        plants.Add("wheat");
    }
    public static void plantCrop(string crop)
    {
        if (plants.Contains(crop.ToLower())) 
        {
        }
    }
