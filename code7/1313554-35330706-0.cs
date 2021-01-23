    public static MyResult createFolding(int id, string name, int qty, string narration, DateTime dt)
    {
        var result = new MyResult();
        try
        {
            // your code
            result.Status = 1;
        }
        catch(Exception e){
            result.Status = 0;
            result.Exception = e;
        }
        return result;
    }
