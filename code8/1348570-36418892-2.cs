       // let's assume that you have a simple class:
        public class PassedData
        {
           public string Name { get; set; } //for textBox1
           public string Name1 { get; set; } //for textBox2
           public string Name3 { get; set; } //for textBox3
           public string Name4 { get; set; } //for textBox4
           public string Name5 { get; set; } //for textBox5
           public int Value { get; set; }
        }
        
    //create object of the class like this and asign values to the properties
    
    PassedData abc=new PassedData();
    abc.Name=TextBox1.Text;
    abc.Name2=TextBox2.Text;
    abc.Name3=TextBox3.Text;
        // then you navigate like this:
       Frame.Navigate(typeof(Page2), abc);
        
        // and in target Page you retrive the information:
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            PassedData data = e.Parameter as PassedData;
        }
