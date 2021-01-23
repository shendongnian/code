    public void RaiseClick1() {
        var clicked1 = Clicked1;
        if (clicked1 != null)
            clicked1(this, EventArgs.Empty);
        if (Command1 != null && Command1.CanExecute(Command1Paramter))
             Command1.Execute(Command1Parameter);
    }
