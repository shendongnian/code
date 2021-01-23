                Console.WriteLine("Enter the matrix");
                int n= Convert.ToInt32(Console.ReadLine());
                int[ , ] matrix=new int[n,n];
                for(int i=0; i<n; i++){
                string line = Console.ReadLine();
                string[] elements = line.Split(' ');
                    for(int j=0; j<n || j < elements.Length; j++){
                        matrix[i,j]=Convert.ToInt32(elements[j]);
                    }    
                }
