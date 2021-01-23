    public class Form1 : Form
    {
        private Race race;
        public Form1()
        {
            race = new Race();
        }
    
        public void button1_Click(object sender, EventArgs e)
        {
            race.position++;
        }
    }
