    var form2 = new Form2(this); // where "this" is your Form1
    class Form2
    {
        private readonly Form1 mainForm;
    
        public Form2(Form1 mainForm)
        {
            this.mainForm = mainForm;
        }
        public void DoSomething()
        {
            var loginCount = mainForm.loginCount; // use it!
        }
    }
