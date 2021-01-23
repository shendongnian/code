    void Activity_Submit_Click(object sender, EventArgs e)
    {
        string[] data = new JavascriptSerializer().Deserialize<string[]>(department_dropdown_items.Value);
        string selectedValue = department_dropdown_selected.Value;
        int fye = Int32.Parse(fye_dropdown.Value);
        String activity_name = activity_name_field.Value;
        String activity_responsible = responsible_field.Value;
        int department = Int32.Parse(department_dropdown.Value);
        String activity_start = datepicker_start.Value;
        String activity_end = datepicker_end.Value;
    }
