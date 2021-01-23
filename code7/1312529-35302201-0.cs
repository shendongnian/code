    public interface IMyInterface
    {
      IContact CurrentContact { get; }
    }
    
    public interface IContact
    {
      DateTime BirthDate { get; }
      // define more needed properties here
    }
    
    public class ContactAdapter : IContact
    {
      private readonly Contact _contact;
    
      public ContactAdapter(Contact contact)
      {
        _contact = contact;
      }
    
      public DateTime BirthDate
      {
        get { return _contact.BirthDate; }
      }
      // delegate more properties to third party Contact class
    }
