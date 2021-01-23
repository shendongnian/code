    public class Form2
    {
       private Form1 _parent; // this will hold the parent until Form2 is disposed.
       ...
       public void Form2(Form1 parent) 
       {
           _parent = parent; // assign Form1 instance to a field.
       }
    
       public void btnClearGrid(object sender, EventArgs e)
       {
          _parent.Clear(); // clear the rows in the datagridview instance within form1.
       }
       ...
    }
