    public class A
    {
       public delegate void ItemSelectedHandler(string title);
       public event ItemSelectedHandler OnItemSelected;
       public void listBox1_SelectedIndexChanged(object sender, EventArg, e)
       {
           //other code
           if(OnItemSelected!=null)
           {
              OnItemSelected("Something");
           }
       }
       public void LaunchB()
       {
          var b = new B(this);
          b.ShowDialog();
       }
    }
    
    public class B
    {
       private A _parent;
       public B(A parent)
       {
          _parent = parent;
          _parent.OnItemSelected += onItemSelected;
       }
       public void onItemSelected(string title)
       { 
          //will fire when selected index changed;
       }
    }
