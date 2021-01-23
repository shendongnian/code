    namespace ConsoleApplication8
    {
        class Sprite
        {
            private Vector3 _position;
    
            public Vector3 Position
            {
                get { return _position; }
                set
                {
                    _position = value;
                    // HandleEvent();
                }
            }
    
            public Sprite()
            {
                _position = new Vector3();
            }
        }
    
        class Vector3
        {
            public float X, Y, Z;
        }
        
        class Program
        {
            static void Main()
            {
                Sprite sprite = new Sprite();
    
                sprite.Position.X += 4.0F;
            }
        }
    }
