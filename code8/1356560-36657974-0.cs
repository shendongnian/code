    using System;
    using System.Windows.Forms;
    using System.Collections.Generic;
    
    public class Starbucks
    {
     public static void Main()
    {
     double[] x = {4.2, 5.7, 3.6, 9.1, 2.7, 8.4 };
     }
    
    static void MyGenerics(double[] x)
    {
     foreach (double d in x)
     {
      MessageBox.Show(x);
     }
    }
    }
