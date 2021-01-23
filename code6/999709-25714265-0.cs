    partial class Info {
      protected override PageInfo createParentPageInfo() {
        var conditionalParent = MyParentPage.GetInfo();
        return conditionalParent.UserCanAccessPageAndAllControls ? conditionalParent : null;
      }
      protected override ConnectionSecurity ConnectionSecurity { get { return ConnectionSecurity.SecureIfPossible; } }
    }
