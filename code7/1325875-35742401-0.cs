    public class Class2
    {
        public ObservableCollection<Message> messages {get;set;}
        
        public void ReceiveMessage(ObservableCollection<Message> list)
        {
            messages = list;
        }
    }
    
    public class Class1
    {
        ...
        ObservableCollection<Message> list = new ObservableCollection<Message>();
    
        Class2.ReceiveMessage(list);
    
        var updatedList = Class2.message;
        ...
    }
