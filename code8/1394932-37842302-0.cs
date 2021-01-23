    public interface IAddPersonObserver
    {
        void OnPersonAdded(Person person);
    }
    public interface IAddPersonObservable
    {
        void Subscribe(IAddPersonObserver observer);
        void Unsubscribe(IAddPersonObserver observer);
    }
    public class MainWindow : IAddPersonObserver
    {
        ...
        
        private void button_Click(object sender, RoutedEventArgs e)
        {
            PersonInput x = new PersonInput(); 
            x.Subscribe(this);
            x.Show();
        }
        public void OnPersonAdded(Person addedPerson)
        {
            addPerson(addedPerson); // or whatever view update code you want
        }
    }
