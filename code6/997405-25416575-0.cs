    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication1
    {
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream fs = File.Create("imagedata.csv"))//or whatever here. I would use a save file dialog
            using(StreamWriter sw = new StreamWriter(fs))
            {
                sw.Write("column headers");// if so desired 
                for (int y = 0; y < Y; y++)
                {
                    for (int x = 0; x < X; x++)
                    {
                        if(x == x-1)//last element in row
                        {sw.Write( (double)Pixels[y, x] );}
                        else
                        {sw.Write( (double)Pixels[y, x] + "\t" );} // use a tab delimmiter to avoid collision with commas and decimals Excel can handle this just fine
                    }
                    sw.WriteLine(); // newline is next row
                }  
            }
        }
    }
    }
