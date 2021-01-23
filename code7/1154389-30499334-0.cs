            // Create the MATLAB instance 
            MLApp.MLApp matlab = new MLApp.MLApp();
            // Change to the directory where the function is located 
            matlab.Execute(@"cd C:\matlabInC");
            // Define the output 
            object result = null;
            // creat two array
            double[,] par1 = new double[3, 3];
            double[,] par2 = new double[3, 3];
            
            //Give value to them.....
            // Call the MATLAB function myfunc
            matlab.Feval("myFunc", 2, out result, 3.14, 42.0, "world", par1, par2);
            // Display result 
            object[] res = result as object[];
           
            object arr = res[0];
            Console.WriteLine(arr.GetType());
            // addition resualt
            double[,] da = (double[,])arr;
            //Show Result of Addition.....
            for (int i = 0; i < da.GetLength(0); i++)
            {
                for (int j = 0; j < da.GetLength(1); j++)
                {
                    Console.WriteLine("add[" + i + "," + j + "]= " + da[i, j] + ", ");
                }
            }
            // subtraction resualt
			arr = res[1];
            double[,] da2 = (double[,])arr;
            //Show subtraction result...
            for (int i = 0; i < da2.GetLength(0); i++)
            {
                for (int j = 0; j < da2.GetLength(1); j++)
                {
                    Console.WriteLine("sub[" + i + "," + j + "]= " + da2[i, j] + ", ");
                }
            }
            
            Console.ReadLine(); 
