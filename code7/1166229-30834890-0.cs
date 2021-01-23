    public class SomeClass
    {
        public Character player1 = new Character(); // this will compile
        public void SomeMethod()
        {
            public Character player2 = new Character(); // this won't compile
        }
    }
