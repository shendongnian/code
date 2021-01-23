     try
            {
                string mystring = "this is a string and can't be converted to int ";
                int myint = int.Parse(mystring);
            }
            catch
            {
                Console.WriteLine("Please Enter a vaild Data Type");
            }
