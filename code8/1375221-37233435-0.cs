    abstract class MyBehaviour
    {
        public Position Position { get; private set; }
        public Handler Handler { get; private set; }
        protected MyBehaviour(int x, int y, Handler handler) {
            this.Position = new Position(x, y);
            this.Handler = handler;
        }
    }
    class Behaviour1 : MyBehaviour {
      /* Whatever */
    }
    class Behaviour2 : MyBehaviour {
      /* Whatever */
    }
