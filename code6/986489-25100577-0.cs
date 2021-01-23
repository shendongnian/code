    public A getObject()
    {
        switch(MysteryLogic())
        {
            case MysteryLogicResult.One:
                return new A1();
            case MysteryLogicResult.Two:
                return new A2();
            case MysteryLogicResult.Three:
                return new A3();
        }
    }
