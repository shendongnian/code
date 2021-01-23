     int i = 25;
     double d = 3.14157;
     bool b = true;
     string s = "I am happy";    
    using (var bw = new BinaryWriter(new FileStream("mydata", FileMode.Create))
    {           
        bw.Write(i);
        bw.Write(d);
        bw.Write(b);
        bw.Write(s);
    }
