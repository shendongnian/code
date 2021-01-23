    using System;
    using System.Windows.Forms;
    using System.Collections.Generic;
    
    public class Starbucks
    {
     public static void Main()
    {
      double[] x = {4.2, 5.7, 3.6, 9.1, 2.7, 8.4 };
      MyGenerics(x);
     }
    
    static void MyGenerics(double[] xx)
    {
     foreach (double d in xx)
     {
      MessageBox.Show(d);
     }
    }
    }
