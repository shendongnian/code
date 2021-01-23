    class Class
    {
        public Class(string string1)
        {
            if(string1.Length > 10)
                throw new Exception("Length Exceeded than limit");
        }
    }
    
    class Program
    {
        static void Main()
        {
            Class obj;
            try
            {
               obj = new Class("stri");
            }
            catch
            {
               MessageBox.Show("Error");
            }
        }
    }
