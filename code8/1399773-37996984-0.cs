    public List<string> search (string id){
        DataContextClass db = new DataContextClass();         
        List<string> results = db.searchProgramUnit(id).ToList();
        return results;
    }
