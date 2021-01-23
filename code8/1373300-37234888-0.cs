    var myTEE = System.Globalization.StringInfo.GetTextElementEnumerator( "కాకికు");
    while (myTEE.MoveNext())  {
         Console.WriteLine( "[{0}]:\t{1}\t{2}", 
             myTEE.ElementIndex, myTEE.Current, myTEE.GetTextElement() );
    }
