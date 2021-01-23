    public void addComment(int titleNum, string comment) {
        if (!this.Data.ContainsKey(titleNum) {
            this.Data.Add(titleNum, new List<string>());
        }
        this.Data[titleNum].Add(comment);
    }
