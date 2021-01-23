    public class Form1
    {
         
        public Form1()
        {
            MyDelegate delegate1 = new MyDelegate(ShowSelectedItem);
        }
        public void LaunchForm2()
        {
            
        }
        private void ShowSelectedItem(string result)
        {
            throw new NotImplementedException();
        }
    }
    public class Form2
    {
        private MyDelegate form2Delegate;
        public Form2(MyDelegate del = null)
        {
            form2Delegate = del;
        }
        public void LaunchForm3()
        {
        }
     
    }
    public class Form3
    {
        private MyDelegate form3Delegate;
        public Form3(MyDelegate del = null)
        {
            form3Delegate = del;
        }
        public void SelectedItemTriggered(string selectedItem)
        {
            form3Delegate(selectedItem);
            //This will trigger method ShowSelectedItem of Form1
        }
    }
