    public void UpdateRow(GenderDDUpdateOrderIndexViewModel model, int Id, int fromPosition, int toPosition)
            {
                using (var ctx = new ApplicationIdentityDbContext())
                {
                   var GenderList = ctx.GenderDD.ToList();
                   ctx.GenderDD.First(c => c.OrderIndex == Id).OrderIndex = toPosition;
                   ctx.SaveChanges();
                }
            }
