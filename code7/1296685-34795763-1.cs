    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace testforms
    {
        public partial class Form1 : Form
        {
            private classx duration = null;
            public Form1()
            {
                InitializeComponent();
                duration = new classx(this);
            }
    
            private void button1_Click_1(object sender, EventArgs e)
            {
                MessageBox.Show("From " + comboBox1.Text + " to " + comboBox2.Text + " it takes around " + duration.Times());
            }
        }
    
        public class classx 
        {
            public string[] Places = new string[] { "Berlin", "Paris", "London", "Rome", "Tirana", "Istanbul" };
            public int[] Kilometers = new int[] { 50, 30, 70, 110, 40, 90 };
    
            Form1 form1 = null;
    
            public classx(Form1 form)
            {
                form1 = form;
    
                form1.comboBox1.Items.AddRange(Places);
                form1.comboBox2.Items.AddRange(Places);
            }
    
            public TimeSpan Times()
            {
                double length = 0; double hour = 0, minute = 0, seconds = 0; int hour1 = 0, minute1 = 0, second1 = 0;
    
                for (int i = 0; i <= 5; i++)
                {
                    // change to SelectedItem because selected text will always be "" empty string.
                    if (form1.comboBox2.SelectedItem.ToString() == Places[i])
                    {
                        length = Kilometers[i];
                    }
                }
                hour = (length / 80);
                hour1 = Convert.ToInt32(Math.Truncate(hour));
                minute = (hour - Math.Truncate(hour)) * 60;
                minute1 = Convert.ToInt32(Math.Truncate(minute));
                seconds = (minute - Math.Truncate(minute)) * 60;
                second1 = Convert.ToInt32(Math.Truncate(seconds));
                TimeSpan time = new TimeSpan(Convert.ToInt32(hour), Convert.ToInt32(minute1), Convert.ToInt32(second1));
                TimeSpan TimeLength = new TimeSpan(hour1, minute1, second1);
                return TimeLength;
            }
        }
    }
