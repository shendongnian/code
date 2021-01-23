    public class SOOrderEntryExt : PXGraphExtension<SOOrderEntry>
    {
        public void SOOrder_OrderType_FieldDefaulting(PXCache sender, PXFieldDefaultingEventArgs e)
        {
            var query = new PXSelectJoin<SOOrderType,
                    InnerJoin<PX.SM.UsersInRoles,
                        On<PX.SM.UsersInRoles.rolename,
                            Equal<SOOrderTypeExt.usrUserRole>>>,
                    Where<PX.SM.UsersInRoles.username,
                        Equal<Current<AccessInfo.userName>>>>(Base);
            var orderType = query.SelectSingle();
            if (orderType != null)
            {
                e.NewValue = orderType.OrderType;
                e.Cancel = true;
            }
        }
        public void SOOrder_RowSelected(PXCache sender, PXRowSelectedEventArgs e)
        {
            SOOrder order = e.Row as SOOrder;
            bool disabled = Base.soordertype.Current == null;
            if (!disabled)
            {
                string userRole = Base.soordertype.Current.GetExtension<SOOrderTypeExt>().UsrUserRole;
                if (string.IsNullOrEmpty(userRole) || !PXContext.PXIdentity.User.IsInRole(userRole))
                {
                    disabled = true;
                }
            }
            if (disabled)
            {
                SetReadOnly(true);
                sender.AllowInsert = true;
                sender.RaiseExceptionHandling<SOOrder.orderType>(order, order.OrderType, 
                    new PXSetPropertyException("Access not granted for current user", PXErrorLevel.Warning));
            }
        }
        protected void SetReadOnly(bool isReadOnly)
        {
            foreach (PXCache cache in Base.Caches.Values)
            {
                cache.AllowDelete = !isReadOnly;
                cache.AllowUpdate = !isReadOnly;
                cache.AllowInsert = !isReadOnly;
            }
        }
    }
