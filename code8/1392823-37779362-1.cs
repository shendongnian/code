    public partial class ProfileController : UIViewController
    {
        private int _id;
    
        public void SetupProfile (int id)
        {
            // Save the Id if necessary.
            _id = id;
            // Add event with this id related.
        }
        public override void ViewDidLoad() 
        { 
            Console.WriteLine("ViewDidLoad() called");
        }
    }
