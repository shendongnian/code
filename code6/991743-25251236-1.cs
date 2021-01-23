    using (var foo = SomeDisposable)
    {
        if (SomCondition)
        {
            if (SomeOtherCodition)
            {
                return SomeThing;
            }
            else
            { 
                return SomethingElse;
            }
        }
        else
            return HereAllCasesAreHandled;
    }
    // following code is in the void because it can never be executed:
    return RedirectToAction("WorkspaceHome", "Workspace");
