    public class F : IElement
    {
        public int CurrentHp { get; private set };
        public bool IsDead { get { return CurrentHp <= 0; } }
        public F() { CurrentHp = 10; }
    }
