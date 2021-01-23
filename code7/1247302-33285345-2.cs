    List<Description> list = new List<Description>
    {
        new Description {Desc1 = "Des A" ,Desc3 = "ujeuejduejtest test Card#9999"},
        new Description {Desc1 = "Des B" ,Desc3 = " test test test Card#1234"},
        new Description {Desc1 = "Des C" ,Desc3 = "2323fseff dsftest Card#9999"},
        new Description {Desc1 = "Des D" ,Desc3 = " jjjjj iiiiii kkkk Card# 1234"},
    };
 
    var result = ...;            
    foreach (var tuple in result)
    {
        Console.Write("CARD#{0} : ",tuple.Item1);
        foreach (var description in tuple.Item2)
        {
            Console.Write(description.Desc1 + ", ");
        }
        Console.WriteLine();
    }
