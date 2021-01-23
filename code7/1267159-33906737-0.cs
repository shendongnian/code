    [DataContract]
    public class ViewDetails
    {
       [DataMember]  
       public string TitleView { get; set; }
       [DataMember]
       public string BodyView { get; set; }
       [DataMember]
       public string AuthorView { get; set; }
        public ViewDetails() { }
        public ViewDetails(string myTitleView, string myBodyView, string myAuthorView)
        {
         this.TitleView = myTitleView;
         this.BodyView = myBodyView;
         this.AuthorView = myAuthorView;
        }
    }
