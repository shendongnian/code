        enum Curtain
        {
            Up,
            Down
        }
        Curtain state;
        public void Up()
        {
            state = Curtain.Up;
            stateChange.Set();
            stateChangeDone.Reset();
        }
        public void Down()
        {
            state = Curtain.Down;
            stateChange.Set();
            stateChangeDone.Reset();
        }
