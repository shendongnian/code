    StringBuilder b = new StringBuilder();
    b.Append("some words");
    b.Append(" to test   ");
               
    do
    {
        if(char.IsWhiteSpace(b[b.Length - 1]))
        {
             b.Remove(b.Length - 1,1);
        }
    }
    while(char.IsWhiteSpace(b[b.Length - 1]));
              
    string get = b.ToString();
