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
    // following code is in nirvana:
    return RedirectToAction("WorkspaceHome", "Workspace");
