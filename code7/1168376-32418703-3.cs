    // this program allows setting of input and output codepages..
    // and this program can show how chcp<ENTER> checks only the input codepage
    // and chcp 850 or chcp num, changes both the input and output codepages
    
    class chcpautility
    {
     static string progname=System.AppDomain.CurrentDomain.FriendlyName;
    
    
    static void Main(string[] args)
    {
    
    progname=progname.Substring(0,progname.Length -4);
    
    if (args.Length==0)
    {
       // these aren't equivalent oddly enough System.Console.InputEncoding.WindowsCodePage+"- "+System.Console.InputEncoding.EncodingName);
    
       System.Console.WriteLine("Input encoding is: "+System.Console.InputEncoding.CodePage+"- "+System.Console.InputEncoding.EncodingName);
       System.Console.WriteLine("Output encoding is: "+System.Console.OutputEncoding.CodePage+"- "+System.Console.OutputEncoding.EncodingName);
       
       //System.Console.WriteLine("To change encoding, use "+progname+" 850 or "+progname+" i 850 or "+progname+" o 850 or "+progname+" io 850 or chcpa -?"); 
       //prog io 850 is the same as prog 850  
    
        printbasicusage();
    }
    
    
    if (args.Length==1 && (args[0]=="/?"|args[0]=="-?"|args[0]=="-h"|args[0]=="--help"))
    {
      
      System.Console.WriteLine("progname num e.g. chcpa 850  to change both input and output encodings");
      System.Console.WriteLine("chcpa i 850  would change just the input encoding");
      System.Console.WriteLine("chcpa o 850  would change just the output encoding");
      System.Console.WriteLine("chcpa io 850  would change both input and output encodings. That's the same as chcpa 850");
      System.Console.WriteLine("chcpa<ENTER> will display current encodings");
      System.Console.WriteLine("chcpa showencodings  <-- will list encodings, you can add to the list by editing this source code");
     
     System.Environment.Exit(1);
    
    }
    
    if (args.Length==1 && (args[0]=="showencodings" | args[0]=="showencoding")) 
    {
    
    // from here
    // https://msdn.microsoft.com/en-us/library/system.text.encoding(v=vs.110).aspx
    
    System.Console.WriteLine("850	ibm850		Western European (DOS)");
    System.Console.WriteLine("852	ibm852		Central European (DOS)");
    System.Console.WriteLine("862	DOS-862		Hebrew (DOS)  (Can use Courier New for Hebrew)"); 
    System.Console.WriteLine("1146	IBM01146	IBM EBCDIC (UK-Euro)");
    System.Console.WriteLine("1200	utf-16		Unicode (Can use DejaVu Sans Mono, or Droid Sans Mono for Unicode)"); 
    System.Console.WriteLine("1201	unicodeFFFE	Unicode (Big endian) (Can use DejaVu Sans Mono, or Droid Sans Mono for Unicode)"); 
    System.Console.WriteLine("1252	Windows-1252	Western European (Windows)");
    System.Console.WriteLine("1255	windows-1255	Hebrew (Windows)");
    System.Console.WriteLine("12000	utf-32		Unicode (UTF-32) (Can use DejaVu Sans Mono, or Droid Sans Mono for Unicode)"); 
    System.Console.WriteLine("12001	utf-32BE	Unicode (UTF-32 Big endian) (Can use DejaVu Sans Mono, or Droid Sans Mono for Unicode)"); 
    System.Console.WriteLine("20127	us-ascii	US-ASCII");
    System.Console.WriteLine("20285	IBM285		IBM EBCDIC (UK)");
    System.Console.WriteLine("20424	IBM424		IBM EBCDIC (Hebrew) (Can use Courier New for Hebrew)"); 
    System.Console.WriteLine("65000	utf-7		Unicode (UTF-7) (Can use DejaVu Sans Mono, or Droid Sans Mono for Unicode)"); 
    System.Console.WriteLine("65001	utf-8		Unicode (UTF-8) (Can use DejaVu Sans Mono, or Droid Sans Mono for Unicode)"); 
     System.Environment.Exit(1);
    
    }
    
    
    
    
    if (args.Length==1)
    {
      //System.Text.Encoding ei=System.Console.InputEncoding;  //so can later say what it was
      //System.Text.Encoding eo=System.Console.OutputEncoding; //so can later say what it was
    
      System.Console.InputEncoding=System.Text.Encoding.GetEncoding(int.Parse(args[0]));
      System.Console.OutputEncoding=System.Text.Encoding.GetEncoding(int.Parse(args[0]));
    
       //System.Console.WriteLine("Input encoding was: "+ei.CodePage+"- "+ei.EncodingName);
       //System.Console.WriteLine("Output encoding was: "+eo.CodePage+"- "+eo.EncodingName);
    
    
       System.Console.WriteLine();
    
       System.Console.WriteLine("Input encoding is now: "+System.Console.InputEncoding.CodePage+"- "+System.Console.InputEncoding.EncodingName);
       System.Console.WriteLine("Output encoding is now: "+System.Console.OutputEncoding.CodePage+"- "+System.Console.OutputEncoding.EncodingName);
    
    }
    if (args.Length==2) 
    {
    //System.Console.WriteLine("Usage- prog i o num e.g. prog i 850 or prog o 850 or prog io 850");
    
      //System.Text.Encoding ei=System.Console.InputEncoding;  //so can later say what it was
      //System.Text.Encoding eo=System.Console.OutputEncoding; //so can later say what it was
    
     if (args[0]=="i") System.Console.InputEncoding=System.Text.Encoding.GetEncoding(int.Parse(args[1]));
     if (args[0]=="o") System.Console.OutputEncoding=System.Text.Encoding.GetEncoding(int.Parse(args[1]));
     if (args[0]=="io") {
      System.Console.InputEncoding=System.Text.Encoding.GetEncoding(int.Parse(args[1]));
      System.Console.OutputEncoding=System.Text.Encoding.GetEncoding(int.Parse(args[1]));
     }
    
    
       //System.Console.WriteLine("Input encoding was: "+ei.CodePage+"- "+ei.EncodingName);
       //System.Console.WriteLine("Output encoding was: "+eo.CodePage+"- "+eo.EncodingName);
    
    
       //System.Console.WriteLine();
    
       System.Console.WriteLine("Input encoding is now: "+System.Console.InputEncoding.CodePage+"- "+System.Console.InputEncoding.EncodingName);
       System.Console.WriteLine("Output encoding is now: "+System.Console.OutputEncoding.CodePage+"- "+System.Console.OutputEncoding.EncodingName);
    
    
    //System.Console.OutputEncoding=System.Text.Encoding.GetEncoding(65001);
    
    
    } //if
     
    
    if (args.Length>2) {System.Console.WriteLine("Too many parameters, check usage, try chcpa<ENTER>");}
    
    } //main
    
    public static void printbasicusage()
    {
       System.Console.WriteLine("To change encoding, use "+progname+" 850 or "+progname+" i 850 or "+progname+" o 850 or "+progname+" io 850"); 
       //prog io 850 is the same as prog 850  
       System.Console.WriteLine("For fuller and further options, use " + progname + "  /?");
       
    } //printbasicusage()
    
    } //class
