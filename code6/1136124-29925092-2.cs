    using System;
    namespace RectangleApplication
    {
       class Rectangle 
       {
          // member variables
          double length;
          double width;
          
          public Rectangle(double length, double width) 
          {
              this.length = length;
              this.width = width;
          }
          
          public double GetArea()
          {
             return length * width; 
          }
          
          public void Display()
          {
             Console.WriteLine("Length: {0}", length);
             Console.WriteLine("Width: {0}", width);
          }
       }
       
       class ExecuteRectangle 
       {
          static void Main(string[] args) 
          {
             Rectangle r = new Rectangle();
             r.Display();
             Console.WriteLine("Area: {0}", r.GetArea());
             Console.ReadLine(); 
          }
       }
    }
