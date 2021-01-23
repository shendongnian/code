    public static void SetDefaultGroup(Group group)
    {
         var ctx = group.Context as ClientContext;
         ctx.Web.AssociatedMemberGroup = group;
         ctx.Web.Update();
         ctx.ExecuteQuery();
    }
