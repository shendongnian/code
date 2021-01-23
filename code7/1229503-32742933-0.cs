    class Program
       {
            public static void Main()
            {
                Program P = new Program(); //Creating an instance.
                IAssembly iAssebly = ((IAssembly)P); //Casting it to IAssembly.
                IDetail iDetail = ((IDetail)P); //Casting it to IDetail.
                IAssembly iDetailToIAssembly = ((IAssembly)iDetail); //Casting IDetail to IAssemmbly.
                IDetail iAssemblyToIDetail = ((IDetail)iAssebly); //Casting IAssemmbly to IDetail.
            }
        }
