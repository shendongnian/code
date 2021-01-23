    public List<object> unnamed(TSomething x, bool s) {
       return new List<object>
                                            {
                                                Magic(x.PropertyOne, s),
                                                Magic(x.PropertyTwo, s),
                                                Magic(x.PropertyThree, s),
                                                x.PropertyFour,
                                                x.PropertyFive,
                                                x.NoOperationRate,
                                             };
    }
