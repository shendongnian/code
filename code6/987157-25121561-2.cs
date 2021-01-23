    public class MoveCustomerWindow : Window
    {
        private readonly ICommandHandler<MoveCustomerCommand> moveCustomerHandler;
        public MoveCustomerWindows(
            ICommandHandler<MoveCustomerCommand> moveCustomerHandler)
        {
            this.moveCustomerHandler = moveCustomerHandler;
        }
        public void Button1Click(object sender, EventArgs e)
        {
            // Here we call the command handler and pass in a newly created command.
            this.moveCustomerHandler.Handle(new MoveCustomerCommand
            {
                CustomerId = this.CustomerDropDown.SelectedValue,
                NewAddress = this.AddressDropDown.SelectedValue,
            });
        }
    }
