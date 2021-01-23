    var listOfA = new List<A>
                  {
                      new A
                      {
                          Name = "a1",
                          Years = new Dictionary<int, List<int>>
                                  {
                                      {2015, new List<int> {3, 4, 5, 6}},
                                      {2016, new List<int> {2, 8, 9, 10}}
                                  }
                      },
                      new A
                      {
                          Name = "a2",
                          Years = new Dictionary<int, List<int>>
                                  {
                                      {2013, new List<int> {3, 4, 5, 6}},
                                      {2014, new List<int> {2, 8, 9, 10}}
                                  }
                      },
                      new A
                      {
                          Name = "a3",
                          Years = new Dictionary<int, List<int>>
                                  {
                                      {2015, new List<int> {3, 4, 5, 6}},
                                      {2014, new List<int> {2, 8, 9, 10}}
                                  }
                      },
                      new A
                      {
                          Name = "a4",
                          Years = new Dictionary<int, List<int>>
                                  {
                                      {2014, new List<int> {1, 4, 5, 6}},
                                      {2017, new List<int> {2, 8, 9, 10}}
                                  }
                      }
                  };
    // listOfA is now {a1, a2, a3, a4}
    listOfA = listOfA.OrderBy(a => a.Years.Min(y => y.Key + y.Value.Min() / 13d)).ToList();
    // listOfA is now {a2, a4, a3, a1}
