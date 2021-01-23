    public List<Object> getSpecificObjects(System.Type type)
    {
        List<Object> searchObjects = objects.Objects; //Returns a List of Objects from the class ObjectList
        System.Type searchType = type;
        return (searchObjects.FindAll(x => x.GetType() == searchType));
    }
