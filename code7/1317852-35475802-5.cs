    public interface IExistingInterfaces
    {
        void SomeMethod();
    }
    
    public class NewClassA : ClassA, IExistingInterfaces
    {
        //Do nothing
    }
    
    public class NewClassB : ClassB, IExistingInterfaces
    {
        //Do nothing
    }
    
    
    public class MyClassForGeneralUse : IExistingInterfaces
    {
        private IExistingInterfaces _baseObject;
        public MyClassForGeneralUse(IExistingInterfaces baseObject)
        {
            _baseObject = baseObject;
        }
    
        //Write proxy calls for IExistingInterfaces 
        public void SomeMethod()
        {
            _baseObject.SomeMethod();
        }
    
        //Add new methods here
        public void HandleClicked(object sender, EventArgs e)
        {
            
        }
        //...
        //...
    }
