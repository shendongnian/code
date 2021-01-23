    public void showForm(Form _form, Form _main) {
    if (_main != null)
    {
    if (_main.ActiveMdiChild != null)
    {
        _main.ActiveMdiChild.Close();
    }
    _form.MdiParent = _main;
    _form.Activate();
    _form.Show();
    }
    else
    {
    _form.Activate();
    _form.ShowDialog();
    }
