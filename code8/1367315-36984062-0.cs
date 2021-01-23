    public int Slot1Choice=0;
    public static void EquipSlot1()
    {
         Console.WriteLine("Choose a weapon for slot 1:");
         Console.WriteLine("1. Sword");
         Slot1Choice = int.Parse(Console.ReadLine());
    }
