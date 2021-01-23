    IValueGetter {
        void SetInt(int v);
        void SetString(string v);
    }
    
    abstract class Command {
        abstract void GetValue(IValueGetter g);
    }
    class TalkCommand {
        override void GetValue(IValueGetter g) {
            g.SetString("hello");
        }
    }
    class BuyCommand {
        override void GetValue(IValueGetter g) {
            g.Setint(123);
        }
    }
