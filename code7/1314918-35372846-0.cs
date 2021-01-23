    public partial class Form
     {
        public enregistre Enr {get; private set;}
        public void firstmethod()
         {
          Enr = new enregistre();
          Enr.date = dateTimePicker1.Value.ToShortDateString();
         }
    
        public void secondmethod()
        {
          textBox1.Text = Enr .date;
        }
      }
