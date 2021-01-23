       public class BigViewModel : IModelOptions
        {
            public bool Confirm { get; set; }
            public SmallViewModel SmallView { get; set; }
        }
    
        public class SmallViewModel
        {
            public string Stuff{ get; set; }
        }
    
        public interface IModelOptions
        {
            SmallViewModel SmallView { get; set; }
        }
