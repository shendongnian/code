    public void ActivateItem(object item)
    {
        //  Better if these two classes share a common base class or interface with 
        //  a virtual function to be called in this case, but there I go ranting from 
        //  the pulpit again. 
        if (item is ClassObject)
        {
            //  Stuff
        }
        else if (item is ClassDiagram)
        {
            //  Other stuff
        }
    }
