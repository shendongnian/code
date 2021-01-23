    var needdelete = new List<Target>();
    foreach (Target t in targetList)
    {
        if (t.CalculateDistance(t.EndX, t.EndY) <= 5)
        {
            needdelete.Add(t);           
        }
    }
    targetlist.RemoveRange(needdelete);
