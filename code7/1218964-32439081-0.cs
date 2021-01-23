    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            enum State
            {
                One,
                Two,
            }
            static void Main(string[] args)
            {
                State state = State.A;
                switch (state)
                {
                    case State.One:
                        //Order by item one
                        state = State.Two;
                        break;
                    case State.Two:
                        //Order by item two or three
                        state = State.One;
                        break;
                }
            }
        }
    }
    <!-- end snippet -->
    ​
