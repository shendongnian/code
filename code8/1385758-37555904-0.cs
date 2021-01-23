    public class Form1 : Form
    {
        private TextBox[,] arrayTextBoxenHochpunkte;
        public void SomeMethod()
        {
             int number = 10;            
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
               if (!(string.IsNullOrWhiteSpace(arrayTextBoxenHochpunkte[i,1].Text)))
               {
                 continue;
               }
               arrayTextBoxenHochpunkte[i, 1].Text = "xValue";
               arrayTextBoxenHochpunkte[i, 2].Text = "yValue";
            }
        }
    }
