    public static SmallObject[] FakeList(int size){
        var res = new SmallObject[size];
        for(var c = 0; c != size; ++c)
            res[c] = new SmallObject();
        return res;
    }
    
