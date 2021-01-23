    var original = new int[] { 1, 0, 0, 1, 2, 0, 1 };
    var nonZeroes = original.Where(x => x != 0); //enumerate once
    var numberOfZeroes = original.Count(x => x == 0); //a few ways to calculate this
    //alternate: var numberOfZeroes = original.Count() - nonZeroes.Count(); //might be faster
    return nonZeroes.Concat(Enumerable.Repeat(0, numberOfZeroes)).ToArray();
