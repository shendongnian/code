    public bool tryGetMyObj(out MyObj tryget) {
        if(myObj != null){
            tryget= myObj;
            return true;
        }
        tryget = null;
        return false;
    }
    MyObj tryget;
    if(myObjContainer.tryGetMyObj(out tryget)){ ... }
