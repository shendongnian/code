    public partial class form2 : Form
    {
       private form1 _form1;
    
       public form2(form1 form1)
       {
           _form1 = form1;
       }
       private void SomethingElse(){
         var res = 10 - _form1.v1;
       }
    }
