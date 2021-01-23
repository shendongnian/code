    using System;
    using System.Text;
    using System.IO;
    /// <summary>
    /// Programm zur Verschlüsselung mittels Caesar-Verschlüsselung
    /// </summary>
    class Caesar
    {
    /// <summary>
    /// Sortier-Arrays
    /// </summary>
    static char [] unverändert=new char[]  {'0','1','2','3','4','5','6','7','8','9','Ä','ä',
                                            'Ö','ö','Ü','ü','ß',' ',',','.','-','?','!','"','+','/'};
    static char[] groß = new char[] {'A','B','C','D','E','F','G','H','I','J','K','L','M','N',
                                        'O','P','Q','R','S','T','U','V','W','X','Y','Z'};
    static char[] klein = new char[] {'a','b','c','d','e','f','g','h','i','j','k','l','m','n',
                                        'o','p','q','r','s','t','u','v','w','x','y','z' };
    /// <summary>
    /// Main-Methode unkommentiert.
    /// </summary>
    public static void Main()
    {
        string ausgabe;
        int schlüssel;
        Console.WriteLine("Geben sie den zu verschlüsselnden Text ein:");
        string eingabe = Console.ReadLine();
       New:
        Console.WriteLine("Geben sie den Schlüssel an:");
        try {schlüssel = Int32.Parse(Console.ReadLine()); }
        catch (FormatException)
        {
            Console.WriteLine("Der Schlüssel muss numerisch sein!");
            goto New;
        }
        ausgabe = encode(eingabe,schlüssel);
        decode(ausgabe, schlüssel);
        
    }
    /// <summary>
    /// Decodierungsmethode
    /// </summary>
    /// <param name="s">Zu decodierender String</param>
    /// <param name="z">Schlüssel</param>
    static void decode(string s,int z)
    {
        StringBuilder sb = new StringBuilder();
        char tmp = ' ';
        z = z % 26;
        foreach (char c in s)
        {
            for (int i = 0; i <= 25;i++ )
            {
                switch (Char.Equals(c, klein[i]))
                {
                    case true:
                        try { tmp = klein[i - z]; }
                        catch (IndexOutOfRangeException)
                        {
                            tmp = klein[i - z + 26];
                        }
                        sb.Append(tmp); break;
                    case false: break;
                }
            
                switch (Char.Equals(c, groß[i]))
                {
                    case true:
                        try { tmp = groß[i - z]; }
                        catch (IndexOutOfRangeException)
                        {
                            tmp = groß[i - z + 26];
                        }
                        sb.Append(tmp); break;
                    case false: break;
                }
                switch (Char.Equals(c, unverändert[i]))
                {
                    case true:
                        tmp = unverändert[i];
                        sb.Append(tmp); break;
                    case false: break;
                }
            }
            }
        
        Console.WriteLine(sb);
    }
    /// <summary>
    /// Codierungsmethode
    /// </summary>
    /// <param name="s">Zu codierender String</param>
    /// <param name="z">Schlüssel</param>
    /// <returns>codierter String</returns>
    static string encode(string s,int z)
    {
        StringBuilder sb = new StringBuilder();
        char tmp=' ';
        z = z % 26;
        foreach (char c in s)
        {
            for (int i = 0; i <= 25;i++ )
            {
                switch (Char.Equals(c, klein[i]))
                {
                    case true:
                        try { tmp = klein[i + z]; }
                        catch (IndexOutOfRangeException)
                        {
                            tmp = klein[i + z - 26];
                        }
                        sb.Append(tmp); break;
                    case false: break;
                }
            
                switch (Char.Equals(c, groß[i]))
                {
                    case true:
                        try { tmp = groß[i + z]; }
                        catch (IndexOutOfRangeException)
                        {
                            tmp = groß[i + z - 26];
                        }
                        sb.Append(tmp); break;
                    case false: break;
                }
                switch (Char.Equals(c, unverändert[i]))
                {
                    case true:
                        tmp = unverändert[i];
                        sb.Append(tmp); break;
                    case false: break;
                }
            }
            
            }
        
        Console.WriteLine(sb);
        return sb.ToString();
        
    }
}
