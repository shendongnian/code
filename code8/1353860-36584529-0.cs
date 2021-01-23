    String a = "testname(";
    
    String b = "testname(Val)";
    int x = b.IndexOf(a);
    
    If (richTextBox1.Text.Contains(a)){
    if (x != -1) 
    {
        string final = b.Substring(x + a.Length);
        
    }
    }
