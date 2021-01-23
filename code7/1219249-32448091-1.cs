    private void ToWhom(string userRole)
    {
        switch (userRole)
        {
            case "employee":
                EmployeeView.Visible = true;
                break;
            case "supplier":
               SupplierView.Visible = true;
            default:
                break;
                GenericView.Visible = true;
                break;
        }
    }
