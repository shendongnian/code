    public class MyViewModel
    {
       public string Name {get;set;}
       public byte[] File {get;set;}
    }
    
    [HttpPost]
    public string Post(MyViewModel vm)
    {
        //save the file in database
    }
