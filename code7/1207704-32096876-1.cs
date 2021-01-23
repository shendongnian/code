    namespace Example
    {
        public partial class Example_Setting : Form
        {
            string somethings; // <-- declare a variable in the class
            public Example_Setting(String somethings)
            {
                  this.somethings = somethings; // save param to variable
            }
            private myPlace()
            {
                 MessageBox.Show(somethings); // now data is here for use
            }
        }
