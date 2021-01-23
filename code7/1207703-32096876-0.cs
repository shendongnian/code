    namespace Example
    {
        public partial class Example_Setting : Form
        {
            string somethings;
            public Example_Setting(String somethings)
            {
                  this.somethings = somethings;
            }
            private myPlace()
            {
                 MessageBox.Show(somethings);
            }
        }
