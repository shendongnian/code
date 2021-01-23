    int result, result2, result3;
    
    private void GetResult(string msg)
    {
        int temp;
        do
        {
           Console.Write(msg);
        }
        while(!Int32.TryParse(Console.ReadLine(), out temp));
    
        return temp;
    }
    
    void Main()
    {
       var result = GetResult("Number one:");
       var result2 = GetResult("Number two:");
       var result3 = GetResult("Number three:");
       Console.WriteLine("summan: " + (result + result2 + result3).ToString());
    }   
