    //in the model
    public class User
    {
	public string txtUserName { get; set; }
	public string txtPassword { get; set; }
	public string txtEmailID { get; set; }
	public string txtAge { get; set; }
	public string txtAdderss { get; set; }
	public string txtGender { get; set; }
    }
    //in the controller
    public ActionResult Registration()
    {
	User userObj = new User(); 
    // or you can make a database call and fill the model object 
	userObj.txtUserName = "Name";
	userObj.txtPassword = "password";
	userObj.txtEmailID = "email";
	userObj.txtAge = "age";
	userObj.txtAdderss = "address";
	userObj.txtGender = "gender";
	return View(userObj);
    }
    //in the view
    @model Model.User
    @using (Html.BeginForm("Registration", "Home"))
    {
    @Html.Label("User Name: "); @Html.TextBoxFor(model => model.txtUserName);
    @Html.Label("Password: "); @Html.TextBoxFor(model => model.txtPassword);
    @Html.Label("Email ID: "); @Html.TextBoxFor(model => model.txtEmailID);
    @Html.Label("Age: "); @Html.TextBoxFor(model => model.txtAge);
    @Html.Label("Adderss: "); @Html.TextBoxFor(model => model.txtAdderss);
    @Html.Label("Gender: ");  @Html.TextBoxFor(model => model.txtGender);
    <input type="button" value="Update" /> }
`
this link might help you with mvc basics
[link][1]
  [1]: https://blog.michaelckennedy.net/2012/01/20/building-asp-net-mvc-forms-with-razor/
