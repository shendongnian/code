    var levelTwoPermutationObjects = Enumerable.Range(0, 4)
                                               .Select(arg => new permutationObject
                                                              {
                                                                  element = number
                                                              })
                                               .ToList();
    Parallel.ForEach(levelTwoPermutationObjects,
                     permutationObject => permutationObject.DoThings());
