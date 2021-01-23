    Interface IForm2
    {
       // your properties
       string PersonName {get;}     // Just an example
       
       // your methods
    }
    class Form1: Form
    {
         private IForm2 _form2;
         
         void Foo()
         {
             var pname = _form2.PersonName;   // Just an example
         }
    }
    class Form2: Form, IForm2
    {
        string PersonName 
        {
             get 
             {
                  return personNameTextBox.Text;
             }
        }
    }
