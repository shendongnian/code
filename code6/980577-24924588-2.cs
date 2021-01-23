    public interface IChild
    {
       void update();
       List<IChild> Parent { get; set; }
    }
