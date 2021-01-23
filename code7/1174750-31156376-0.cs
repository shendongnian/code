    public void Edit()
    {
        using (NestedUnitOfWork nuow = session.BeginNestedUnitOfWork())
        {
            Truck currentTruck = nuow.GetNestedObject(
        xpcTruck[gvTruck.GetDataSourceRowIndex(gvTruck.FocusedRowHandle)])
              as Truck;
            using (frmEditTruck form = new frmEditTruck(currentTruck))
            {
                if (form.ShowDialog() == DialogResult.OK)
                    nuow.CommitChanges();
            }
        }
    }
