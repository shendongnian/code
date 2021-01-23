    protected async void btnLoadData_Click(object sender, EventArgs e)
    {
        //...;
    
        switch (int.Parse(rblDataSource.SelectedValue))
        {
            //...;
    
            case 4:
                RunAsyncBlogs();
    
                break;
    
            default:
                blogs = localGetter.GetBlogs();
                break;
        }
    
        //...;
    }
