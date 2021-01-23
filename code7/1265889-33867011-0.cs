    Please write this code. This will work.
    [Required(ErrorMessage = "Your reason for contacting is required.")]
    public int CustomerLocationID { get; set; }
    Html.DropDownListFor(model => model.CustomerLocationID,Model.CustomerLocations)
    @Html.ValidationMessageFor(m => m.CustomerLocations)
