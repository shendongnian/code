    List<string> numbers= new List<string>();
    StringBuilder sb = new StringBuilder();
    
    foreach( char c in test)
    {
        if (c =='+'|| c =='-'||c =='/'||c =='*')
        {
            //Now here i want to save all chars before '+' '-'  '/'  '*' in my list numbers. in this example: save 100, 20,3,17,2 in my list
            numbers.Add(sb.ToString());
            sb.Clear();
        }
        else
        {
            sb.Append(c);
        }
    }
