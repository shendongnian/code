public class MyViewModel
{
    // fire prop changed event here if this model will be swapped out after the ctor...otherwise don't worry about it
    public Model Model { get; set; }
    private ICommand _clickCommand;
    public ICommand ClickCommand
    {
        get
        {
            return _clickCommand ?? (_clickCommand = new CommandHandler(() => MyAction(), _canExecute)); 
        }
    }
    private bool _canExecute = true;
    public void MyAction()
    {
        Model = new Model();
        Model.TxtBox2 = "Some new value"; 
    }
}
