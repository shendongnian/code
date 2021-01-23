    class Program
    {
        static void Main(string[] args)
        {
            string a= "First";
                string b= "MiddleName";
                string newstring = "";
             string newstring1 = "";
                int length = b.Length;
                for (int l = 0; l < length; l=l+1)
                {
                    if(l%2==0)
                    {
                        if(a.Length > l)
                        {newstring += a[l].ToString();}
                        newstring += b[l].ToString();
                    }
                    if (l % 2 == 1)
                    {
                        if(a.Length > l)
                        {newstring1 += a[l].ToString();}
                        newstring1 += b[l].ToString();
                    }
                }
            Console.ReadLine();
        }
    }
