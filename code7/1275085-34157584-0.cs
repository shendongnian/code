     internal LambdaFrame(MethodSymbol topLevelMethod, CSharpSyntaxNode scopeSyntaxOpt, DebugId methodId, DebugId closureId)
                : base(MakeName(scopeSyntaxOpt, methodId, closureId), topLevelMethod)
            {
                _topLevelMethod = topLevelMethod;
                _constructor = new LambdaFrameConstructor(this);
                this.ClosureOrdinal = closureId.Ordinal;
            // static lambdas technically have the class scope so the scope syntax is null 
            if (scopeSyntaxOpt == null)
            {
                _staticConstructor = new SynthesizedStaticConstructor(this);
                var cacheVariableName = GeneratedNames.MakeCachedFrameInstanceFieldName();
                _singletonCache = new SynthesizedLambdaCacheFieldSymbol(this, this, cacheVariableName, topLevelMethod, isReadOnly: true, isStatic: true);
            }
    ...
    }
