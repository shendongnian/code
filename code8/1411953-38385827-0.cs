    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public enum DatePart
            {
                YEAR,
                MONTH,
                DAY
            }
    
            public DatePart part { get; set; }
            private DateTime previous { get; set; }
            private bool checkSelectedPart { get; set; }
    
    
            public Form1()
            {
                InitializeComponent();
    
                
                dateTimePicker1.ValueChanged += DateTimePicker1_ValueChanged;
                dateTimePicker1.KeyPress += DateTimePicker1_KeyPress;
                previous = dateTimePicker1.Value;
    
            }
    
            private void DateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
            {
                
            }
    
            private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
            {
                if (checkSelectedPart)
                {
                    var dtp = sender as DateTimePicker;
                    TimeSpan change = (dtp.Value - previous);
                    var dayChange = Math.Abs(change.Days);
                    if (dayChange == 1)
                        part = DatePart.DAY;
                    else if (dayChange >= 365)
                        part = DatePart.YEAR;
                    else
                        part = DatePart.MONTH;
    
                    previous = dtp.Value;
    
                    label1.Text = part.ToString();
                }
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                checkSelectedPart = true;
                dateTimePicker1.Focus();
                SendKeys.SendWait("{UP}");
                SendKeys.SendWait("{DOWN}");
                checkSelectedPart = false;
                button1.Focus();
            }
        }
    }
