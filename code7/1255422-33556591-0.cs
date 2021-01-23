     public IEnumerable<FruitTree> getYummyFruitTrees(int type)
                {
                    switch (type)
                    {
                        case 0:
                            return new List<AppleTree>();
                        case 1:
                            return new List<OrangeTree>();
                        default:
                            return null;
                    }
                }
