    BaseListSyntax baseList = null;
    if (this.CurrentToken.Kind == SyntaxKind.ColonToken)
    {
        var colon = this.EatToken(SyntaxKind.ColonToken);
        var type = this.ParseType(false);
        var tmpList = _pool.AllocateSeparated<BaseTypeSyntax>();
        tmpList.Add(_syntaxFactory.SimpleBaseType(type));
        baseList = _syntaxFactory.BaseList(colon, tmpList);
        _pool.Free(tmpList);
    }
