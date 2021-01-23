    TimeSpan pointa = new TimeSpan(int.Parse(comboBox1.Text), int.Parse(comboBox2.Text), int.Parse(comboBox5.Text));
    TimeSpan pointb = new TimeSpan(int.Parse(comboBox3.Text), int.Parse(comboBox4.Text), int.Parse(comboBox6.Text));
    TimeSpan pointc = new TimeSpan(int.Parse(comboBox7.Text), int.Parse(comboBox8.Text), int.Parse(comboBox9.Text));
	
	TimeSpan aTob = pointa > pointb 
		? pointa - pointb 
		: (pointa + TimeSpan.FromDays(1)) - pointb;
