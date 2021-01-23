    private void ToWhom(string userRole)
    {
        switch (userRole)
        {
            case "employee":
                return EmployeeView.Visible = true;
            case "supplier":
                return SupplierView.Visible = true;
            default:
                return GenericView.Visible = true;
        }
    }
