    public class ManagerViewModel
    {
        public string Name;
        public long salary;
        public string workType;
        public List<EmployeeViewModel> Dependents;
        //  User-defined conversion from ManagerViewModel to ShopManager or GardenManager
        public static implicit operator Manager(ManagerViewModel viewModel)
        {
            switch (viewModel.workType)
            {
                case "Shop":
                    // TODO: Do your conversion, Build ShopManager based on ManagerViewModel
                    return new ShopManager();
                case "Garden":
                    // TODO: Do your conversion, Build GardenManager based on ManagerViewModel
                    return new GardenManager();
                default:
                    throw new NotImplementedException();
            }
        }
    }
