    public class SomewhereElse
    {
        public void Main()
        {
            List<Item> itemCollection = new List<Item>();
            itemCollection.Add(new Item<int>(15));
            itemCollection.Add(new Item<string>("text"));
            itemCollection.Add(new Item<Type>(typeof(Image)));
            itemCollection.Add(new Item<Exception>(new StackOverflowException()));
            itemCollection.Add(new Item<FormWindowState>(FormWindowState.Maximized));
            // You get the point..
        }
    }
