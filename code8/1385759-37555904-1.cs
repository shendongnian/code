    public class Form1 : Form
    {
        private TextBox[,] arrayTextBoxenHochpunkte;
        public void SomeMethod()
        {
             int number = 10;
             // This line declares an array with the same name and thus
             // hides the global one declared at the form/class level
             // All your initialization goes into this local one that is
             // lost when you exit from this method..... remove it...
             // TextBox[,] arrayTextBoxenHochpunkte= new TextBox[10,3];
            
             // This line initializes the global array so it is available 
             // also in other methods.....
             arrayTextBoxenHochpunkte= new TextBox[10,3];
             .....
             initialization code 
             .....
        }
        private void addHochpunkt(float xValue, float yValue)
        {
            int i;
            for (i = 0; i < 10; i++)
            {
               // Here you try to reference the global array, but
               // your current code leaves the global one without initialization
               // thus a NullReferenceException..... 
               if (!(string.IsNullOrWhiteSpace(arrayTextBoxenHochpunkte[i,1].Text)))
               {
                 continue;
               }
               // I suppose that you want to write the value 
               // of the two variables not their names.
               arrayTextBoxenHochpunkte[i, 1].Text = xValue.ToString();
               arrayTextBoxenHochpunkte[i, 2].Text = yValue.ToString();
            }
        }
    }
