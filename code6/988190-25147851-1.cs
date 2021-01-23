    public enum TestEnum
    {
        [EnumOrder(Order=2)]
        Second = 1,
    
        [EnumOrder(Order=1)]
        First = 4,
    
        [EnumOrder(Order=3)]
        Third = 0
    }
    var names = typeof(TestEnum).GetWithOrder();
    var names = TestEnum.First.GetWithOrder();
