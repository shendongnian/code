    public class Blog
    {
       public App myApp;
       public String Title;
       public String Message;
       public int Id;
    //constructors
    public Blog() { }
    public Blog(App App) { this.myApp = App; }
    //all getters and setters look like this
    public String getTitle() { return Title; }
    public String getMessage() { return Message; }
    public void setTitle(String t) { Title = t; }
    public void setMessage(String m) { Message = m; }    
 
    }
