    public IEnumerable<CapitalDTO> GetCapital(int? BranchId = null)
    {
            unitOfWork = container.Resolve<IUnitOfWork>();
            var capital = unitOfWork.ItemsInBrranches.GetItemsInBranchesByBranch(BranchId).Select(c => new CapitalDTO
            {
                ItemBranch = c.Branch.Name,
                ItemName = c.Item.Name,
                ItemPrice = c.Item.Price,
                ItemSize = c.Item.Size.Size,
                ItemCount = c.Amount
            });
            return capital;
    }
