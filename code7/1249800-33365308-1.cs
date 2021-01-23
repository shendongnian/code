    Console.WriteLine ("Tn+1 = ({0})Tn +/- ({1})", numberOfTs, AOS);
    Console.Write ("{0}", term1);
    int calc = term1;
    for(int i = 0; i < 6; i++)
    {
        calc = calc * numberOfTs + AOS;   
        Console.Write (", {0}", calc);     
    }
