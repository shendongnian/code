    public WindowControl(ref YourNewClassWithSettings test)
    {
       // example: You can now say TextBox1.Text =  test.StringNumber1;
       // Whatever you change here like test.
       test.StringNumber1 = "IamDone";
       //When you close this window, because test was passed by ref : you
       // will see StringNumber1 = "IamDone" in your main window again
       //when accessing the property of that class. Always pass by ref
       this.Close();
    }
