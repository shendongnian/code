    public void ShowDetails()
    {
        var route = new GetDetails();
        route.myParent = this;
        this.Controls.Add(route);
        route.Show();
    }
    public void CloseAllRoutes()
    {
        foreach (var route in this.Controls.Where( control => control is GetDetails))
        {
            route.Close();
        }
    }
