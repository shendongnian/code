    public List<string> GetAuthorName()
    {
    string []get_author = SetBookInfo(Id, Name); // returns string[]
    List<string> list=new List<string>();
    if (get_author != null && get_author.Length > 0)
     {
       if(get_author[0].ToLower().Equals("success"))
        {
         list.Add("success"); 
         list.Add(get_author[1]);
        }
       else
         list.Add("failed");
      }
    else
        list.Add("problem in accessing the function");
     return list;
    }
