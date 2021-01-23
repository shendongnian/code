    public IAction CreateAction<TA, TP>(ActionParamBase param)
            where TA : IAction, new()
            where TP : ActionParamBase
        {
            Ensure.That(param).Is<TP>();
            return new TA { Param = param as TP };
        }
