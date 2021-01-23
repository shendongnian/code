    List<Node> parents = new List<Node>();
    Random rnd = new Random();
    for (int k = 0; k < 100; k++)
    {
        var parentk = new Root(k);
        for (int kk = 0; kk < 20; kk++)
        {
            var paramkk = new Parameter("simple" + kk, "param1", parentk);
            for (int kkk = 0; kkk < 30; kkk++)
            {
                int dice = rnd.Next(1, 1000000);
                var valkkk = new Value(dice, "bar", paramkk);
            }
    
        }
        parents.Add(parentk);
    }
