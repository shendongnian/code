    public bool CheckUsableID(int id, List<clsSomeObject> someTeamList)
    {
        clsSomeObject newObject = new clsSomeObject();
        newObject = someTeamList;
        foreach(var object in newObject)
        {
            if (newObject.id == id)
            {
                return false;
            }
        }
            return true;
    }
