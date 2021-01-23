    void PlaceEggsInBox(int numEggs, Box box)
    {
        box.BoxContents.Expose();
        if (box.BoxContents.AreVisible)
        {
            int eggsInBox = box.BoxContents.Things.Count(thing => thing is Egg);
            for (int i = 0; i < numEggs - eggsInBox; i++)
            {
                box.BoxContents.Add(new Egg());
            }
        }
    }
