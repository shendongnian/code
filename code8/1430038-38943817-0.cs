            int n = 100;
            //Convert decimal to binary
            string numAsString = Convert.ToString(n, 2);
            char[] NumAsChar = numAsString.ToCharArray();
            
            Console.WriteLine(numAsString);
            //Invert bits 
            for (int i = 0; i < numAsString.Length; i++)
            {
                if (NumAsChar[i] == '0')
                {
                    NumAsChar[i] = '1';
                }
                else
                {
                    NumAsChar[i] = '0';
                }
            }
            
            string NewNumAsString = new string(NumAsChar);
            //Convert inverted binary num to decimal
            long l = Convert.ToInt64(NewNumAsString, 2);
            Console.WriteLine(NewNumAsString);
            Console.WriteLine(l);
