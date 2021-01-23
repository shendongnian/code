    public class SomeOtherClass
    {
        // once you add the 'readonly' keyword, compiler        
        // won't let you accidentally create another instance
        private readonly Logger _logger = new Logger();
        public void SomeMethod()
        {
            // _logger = new Logger(); // <-- this will not compile
            _logger.Append("Some message");
        }
        public void SomeOtherMethod()
        {
            MessageBox.Show(_logger.Merge());
        }
    }
