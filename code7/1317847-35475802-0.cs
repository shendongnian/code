    public interface INewInterfaces
    {
        event EventHandler Clicked;
        bool Enabled { get; }
        void HandleClicked(object sender, EventArgs e);
    }
        
    public class NewClassA : ClassA, INewInterfaces
    {
        //...
    }
        
    public class NewClassB : ClassB, INewInterfaces
    {
        //...
    }
