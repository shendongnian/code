    interface ICommand
    {
        void Execute();
    }
    
    //Create secific command and pass parameters in constructor:
    class Command : ICommand
    {
        public Command(string str)
        {
            //do smth
        }
        void Execute()
        {
            //do smth
        }
    }
    
    Button(Rect rect, string text, ICommand cmd)
    {
        cmd.Execute();
    }
