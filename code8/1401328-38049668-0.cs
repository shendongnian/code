    public class Sample1
    {
        public void Run()
        {
            foreach ( var item in Validate( "foobar" ).Result )
            {
                Console.WriteLine( item );
            }
        }
        // starts some result producing tasks
        // await all of them 
        // return the result of each task
        public async Task<IEnumerable> Validate( string input )
        {
            var tasks = new Task<object>[ ] {
                Task.Run( ()=> (object) ValidateFoo(input) ),
                Task.Run( ()=> (object) ValidateBar(input) ),
            };
            return await Task.WhenAll( tasks );
        }
        private string ValidateFoo( string input )
        {
            return "foo";
        }
        private bool ValidateBar( string input )
        {
            return true;
        }
    }
