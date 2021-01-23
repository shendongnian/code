    private void ToWhom(string userRole)
    {
        switch (userRole)
        {
            case "employee":
                EmployeeView.Visible = true;
                break;
            case "supplier":
               SupplierView.Visible = true;
                break;
            default:
                GenericView.Visible = true;
                break;
        }
    }
