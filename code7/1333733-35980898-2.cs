    void EatAllEggsInBox(Box box)
    {
        box.BoxContents.Expose();
        foreach (Egg egg in box.BoxContents.Things.Where(thing => thing is Egg))
        {
            box.BoxContents.Remove(egg);
            egg.EggContents.Expose();
            if (egg.EggContents.AreVisible) egg.Eat();
        }
    }
