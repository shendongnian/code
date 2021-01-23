    public class UpdateNameCommand : ICommand<UpdateNameContext>
    {
        public void Execute(UpdateNameContext context)
        {
            UpdateEmployeeName(context.NewName);
            UpdateTeam(context.UpdatedBy);
        }
        private void UpdateEmployeeName(string name)
        {
            // ...
        }
        private void UpdateTeam(string updatedBy)
        {
            // ...
        }
    }
