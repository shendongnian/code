    public static void Main()
        {
                       
            string test = GetString("FooBar");           
    
        }
    
        public static string GetString(string valuesNew)
        {
            //string valuesNew = "Foo";
            char[] array = valuesNew.ToCharArray();
            string result = "";
    
            array[0] = char.ToUpper(array[0]);
            result = array[0] + " ";
            
            return result;
        }
