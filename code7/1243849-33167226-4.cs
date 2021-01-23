    class gridRecord : Validateit, IEnumerable<gridField>
    {
        //.. snip
       public IEnumerator<gridField> GetEnumerator()
       {
            yield return Quantity;
            yield return Title;
            yield return Pages;
       }
       public IEnumerator GetEnumerator()
       {
           return GetEnumerator(); // generic version
       }
    }
