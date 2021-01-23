    public interface IItem 
    {
        String Name { get; set; }
    }
    public interface IContainerItem
    {
        List<IItem > ListItems { get; }
    }
