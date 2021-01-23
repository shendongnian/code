     public delegate void MyDelegate(string selectedItem);
    public class Form1
    {
        private MyDelegate delegate1;
        public Form1()
        {
             delegate1 = new MyDelegate(ShowSelectedItem);
             var form2 = new Form2(delegate1);
        }
        public void LaunchForm2()
        {
            
        }
        private void ShowSelectedItem(string result)
        {
           
        }
    }
    public class Form2
    {
        private MyDelegate form2Delegate;
        public Form2(MyDelegate del = null)
        {
            form2Delegate = del;
            var form3 = new Form3(form2Delegate);
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
            SelectedItemTriggered("tes");
        }
        public void SelectedItemTriggered(string selectedItem)
        {
            form3Delegate(selectedItem);
            //This will trigger method ShowSelectedItem of Form1
        }
    }
