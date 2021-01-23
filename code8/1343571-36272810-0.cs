    public  void textToast(string textToDisplay) {               
        Toast.MakeText(this,
        textToDisplay, ToastLength.Long).Show();
    }
    class SampleTabFragment : Fragment
    {
        Button add;
        
        // Remove manual creation code
        // MainActivity main = new MainActivity();
        // ...
        void Click(object sender, EventArgs eventArgs)
        {      
            (Activity as MainActivity).textToast( "I like Toast!"); 
        }
    }
