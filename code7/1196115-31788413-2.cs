    private List<OrganizationUnitTreeViewModel> ConvertOrganizationUnitTree(List<OrganizationUnitTree> tree)
        {
            List<OrganizationUnitTreeViewModel> treeModelList = new List<OrganizationUnitTreeViewModel>();
            foreach (OrganizationUnitTree ou in tree)
            {
                OrganizationUnitTreeViewModel treeModel = new OrganizationUnitTreeViewModel();
                treeModel.Text = ou.OrganizationUnit.Name;
                treeModel.Value = ou.Id.ToString();
                if (ou.Subordinates != null && ou.Subordinates.Count > 0)
                {
                    List<OrganizationUnitTreeViewModel> items = new List<OrganizationUnitTreeViewModel>();
                    items.AddRange(ConvertOrganizationUnitTree(ou.Subordinates));
                    treeModel.Items = items;
                }
                treeModelList.Add(treeModel);
            }
            return treeModelList;
        }
