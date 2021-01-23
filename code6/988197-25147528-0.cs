    namespace Shapes {
       using System.Foo;
       public class Rectangle {
           public Rectangle(int l, int w){}
       }
       //Still in effect
     }
     //Not in effect
    namespace Shapes {
       //Not in effect
       public class Square : Rectangle
       public Square(int l, int w){}
    }
