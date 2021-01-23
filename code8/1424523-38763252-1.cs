        public interface InterfaceResult { }
        public abstract class Result : InterfaceResult { }
        public class ResultA : Result { }
        public class ResultB : Result { }
        public interface InterfaceKing { InterfaceResult Function (); }
        public abstract class King : InterfaceKing
        {
            public abstract InterfaceResult Function ();
        }
        public class KingA : King
        {
            public override InterfaceResult Function () => new ResultA ();
        }
        public class KingB : King
        {
            public override InterfaceResult Function () => new ResultA ();
        }
