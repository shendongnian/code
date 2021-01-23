                String result = "";
                char c =  'A';
                String v = "";
                for (int i = 0; v != "Z99"; i++)    // Loop until you reach Z99
                {
                    v = String.Format("{0}{1:D2}", c, i); // A00,A001.... Z99
                    if (i == 99) { i = 0; c++; }  // Reset counter and increment character
                    result += v +" "; // Just to display the result
                }
                MessageBox.Show(result);
