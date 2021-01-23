    public class items
    {
        public string infoOne { get; set;}
        public string infoTwo { get; set;}
        public string infoOneAndinfoTwo {get; set;}
    }
    async void loadList ()
    {
        var getItems = await phpApi.getEvents ();
        theList = new List <items> ();
        foreach (var currentitem in getItems["results"]) {
            theList.Add (new items () {
                infoOne = currentitem ["name"].ToString (), 
                infoTwo = currentitem ["phone"].ToString (),
                infoOneAndinfoTwo = infoOne + " " + infoTwo
            });
       mylist.ItemsSource = theList;
     }
