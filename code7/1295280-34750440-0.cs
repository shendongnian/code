    public List<string> GetFragment(String p)
    {
        List<SoundFragment> list1 = new List<SoundFragment>();
        List<string> result = new List<string>();
        //make a list and store every string
        foreach(SoundFragment i in list1)
        {
            if (i.Title.Contains(p))
            {
                result.Add(i.Title);
            } 
        }
        //return all the objects from the new list that stores all the string contained in the fragments list
        return result ;
    }
