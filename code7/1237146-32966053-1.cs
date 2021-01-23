    class Pet
                {
                    public string Name { get; set; }
                    public int Age { get; set; }
                }
    
                public static void DefaultIfEmptyEx2()
                {
                    Pet defaultPet = new Pet { Name = "Default Pet", Age = 0 };
    
                    List<Pet> pets1 =
                        new List<Pet>{ new Pet { Name="Barley", Age=8 },
                                       new Pet { Name="Boots", Age=4 },
                                       new Pet { Name="Whiskers", Age=1 } };
    
                    foreach (Pet pet in pets1.DefaultIfEmpty(defaultPet))
                    {
                        Console.WriteLine("Name: {0}", pet.Name);
                    }
    
                    List<Pet> pets2 = new List<Pet>();
    
                    foreach (Pet pet in pets2.DefaultIfEmpty(defaultPet))
                    {
                        Console.WriteLine("\nName: {0}", pet.Name);
                    }
                }
