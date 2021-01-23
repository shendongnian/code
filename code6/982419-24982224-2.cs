    public void ClassifyComments(out IEnumerable<Comment> spam, out IEnumerable<Comment> ham)
    {
       IEnumerable<Comment> hamComments = _commentRepository.FindBy(x => x.IsSpam == false);
       IEnumerable<Comment> spamComments = _commentRepository.FindBy(x => x.IsSpam == true);
    
       //....
       
       // Set the out params
       spam = spamComments;
       ham = hamComments;
    }
