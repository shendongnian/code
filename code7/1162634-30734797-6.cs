    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    
    namespace temp
    {
        class Program
        {
            static void Main(string[] args)
            {
                // init
                string filePath = @"C:\myFile.csv";  
     	        string delimiter = ";";  
                
                // filling data
                double[] dataArray = new double[100];
                for (int i = 0; i < dataArray.Length; i++)
                {
                    dataArray[i] = i;
                }
    
                // positioning data
                string[][] output = new string[101][];
                output[0] = new string[] { "Header 1", "Header 2", "Header 3" };
                for (int i = 0; i < dataArray.Length ; i++)
                {
                    output[i+1] = new string[] { dataArray[i].ToString()};
                }
    
                // creating csv in stringBuilder
     	        StringBuilder sb = new StringBuilder();
                for (int index = 0; index < output.Length; index++)
                {
                    sb.AppendLine(string.Join(delimiter, output[index]));
                }
     	 
                // save in file
     	        File.WriteAllText(filePath, sb.ToString()); 
            }
        }
    }
