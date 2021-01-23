    public class EmployeeView : View 
    {
        public ITemplate Get(EmployeeModel viewModel = null, string message = null)
        {
            return
                TemplateFactory.Load("Employee.tpl")
                                .Model(viewModel)
                                .Set().Set("Message", message);
        }
    }
