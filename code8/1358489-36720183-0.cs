     if (!IsPostBack)
     {
                var dlManagersSource = _dal.GetManagers();
                rdManagers.DataSource = dlManagersSource;
                rdManagers.DataValueField = "LookupValue";
                rdManagers.DataTextField = "LookupDescription";
                rdManagers.DataBind();
    
                // Then add your first item
                var ddlDaysOfWeek = _dal.GetDaysOfWeek().OrderBy(o => o.Order);
                rdDayOfWeek.DataSource = ddlDaysOfWeek;
                rdDayOfWeek.DataValueField = "LookupValue";
                rdDayOfWeek.DataTextField = "LookupDescription";
                rdDayOfWeek.DataBind();
    
                var ddlShiftPatterns = _dal.GetShiftPatternTypes();
                rdAppointmentType.DataSource = ddlShiftPatterns;
                rdAppointmentType.DataValueField = "LookupValue";
                rdAppointmentType.DataTextField = "LookupDescription";
                rdAppointmentType.DataBind();
    }
