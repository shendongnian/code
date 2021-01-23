    using System;
    using static Globals.Commands; // <-- import statically allows methods to be
                                   //     used without class name qualification
    
    namespace RectangleDemo {
        // <rectangle definition here>
    
        class Demo {
            static void Main(string[] args) {
                Rectangle r = new Rectangle();
                Rectangle s = new Rectangle(5, 6);
                r.Display();
                s.Display();
                WaitForReturn();
            }
        }
    }
