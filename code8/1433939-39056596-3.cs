    [HttpPost]
    public string pp(string votingUp, int questionId, int viewNumber, int numberOfAnswer, 
       string titleString, [Bind(Include = "ID,Vote,Answer1,View,Title,
                                                          Question,Date")] Questions questions)
    {
       // to do : Return something
    }
