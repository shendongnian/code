        using (var context = new dbKrunchworkContext())
        {
            edit = context.Purchases.Where(x => x.ID == id).FirstOrDefault();
            if (edit != null)
            {
                fmAddEditPurchase editForm = new fmAddEditPurchase(context, edit);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    //Blabla
                }
            }
        }
