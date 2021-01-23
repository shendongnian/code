    if(condition)
    {
        //Do Task
    }
    else
    {
        Dispatcher.Invoke(new Action(() => {
                    MessageBox.Show(ErrorMsg);
                })
                );
    }
