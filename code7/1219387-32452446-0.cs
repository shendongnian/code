    public class MyChild : MyBase
    {
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Dispose Child's objects
            }
    
            base.Dispose(disposing);
        }
    }
