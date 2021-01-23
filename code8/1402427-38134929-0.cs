    ReviewCommentMsg // VERSION 1
    {
     string : username
     string : comment
    } 
    
    ReviewCommentMsg  // VERSION 2 (added "isLiked")
    {
     string : username
     string : comment
     bool   : isLiked
    } 
    
    ReviewCommentMsg  // VERSION 3 (added "location", removed "isLiked")
    {
     string : username
     string : comment
     string : location
    }
