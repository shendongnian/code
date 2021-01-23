    public List<string> DoThisThing(int i) // use list to return a more concrete type
    {
        List<string> list = new List<string>(); // you really want a *LIST* so why be abstract in your own code innards?
        // List<string> myList = null; <-- superfluous
        if (i > 0)
        {
            list = GetListOfString();
        } // ALWAYS (!) use code blocks, see the book "Clean Code"
        // this problem is solved: in your internal code don't be abstract if you don't need it
        //col.AddRange(...); Can't AddRange as no method
        return list; // Can't do this as it expects return type of Collection<string>
        // you're done...
        // So, to ensure my return is Collection, I have to convert
        // foreach(var item in myList)
        // {
        //     col.Add(item);
        // }
        // return col;
    }
