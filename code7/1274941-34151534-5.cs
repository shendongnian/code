    var quests = test.SelectPickUp();
    if (Questing.Quests.Count == 0)
    {
        quests.Insert(0, CurrentQuest);
        quests.Insert(1, SecondQuest);
        quests.Insert(2, ThridQuest);
    }
