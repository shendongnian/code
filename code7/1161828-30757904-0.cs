    public class EmployeeController : Controller<EmployeeModel>
    {
        public override ControllerResponse Invoke()
        {
            var claims = new List<Claim>{
               
               new Claim(ClaimTypes.Name,Model.Id.ToString()),
               new Claim(ClaimTypes.Name,Model.Name),
               new Claim(ClaimTypes.Name,Model.Surname)
           };
            return newTpl(GetView<EmployeeView().Get(Model,Html.MessageBox.Show(StringTable.EmployeeModel)) , StringTable.PageTitleCreateEmployee);
        }
    }
